using System;
using System.Linq;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pif.Models.DataBaseConnections;
using Pif.Models.Encryption;
using Pif.Models.Entities;
using Pif.Models.Enum;

namespace Pif.Controllers
{
    public class AccountController : Controller
    {
        private readonly PifDataContext _databaseConnection;

        public AccountController(IHostingEnvironment env, PifDataContext databaseConnection)
        {
            _databaseConnection = databaseConnection;
        }
        public IActionResult Profile()
        {
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register([FromBody] AppUser model)
        {
            try
            {
                var username = model.Username.ToLower();
                var email = model.Email.ToLower();
                var appUser = new AppUser
                {
                    Name = model.Name,
                    Mobile = model.Mobile,
                    Email = model.Email,
                    MobileExtension = null,
                    Password = new Hashing().HashPassword(model.ConfirmPassword),
                    ConfirmPassword = new Hashing().HashPassword(model.ConfirmPassword),
                    Username = model.Username,
                    Status = model.Status,
                    Address = model.Address,
                    BackgroundPicture = model.BackgroundPicture,
                    ProfilePicture = model.ProfilePicture,
                    Biography = model.Biography,
                    DateOfBirth = model.DateOfBirth,
                    Website = model.Website,
                    RoleId = model.RoleId,
                    DateCreated = DateTime.Now,
                    DateLastModified = DateTime.Now,
                    CreatedBy = model.CreatedBy,
                    LastModifiedBy = model.LastModifiedBy,
                    HasSocialMediaLogin = false,
                    AccountType = LoginType.Platform.ToString()
                };
                //invalid user becuase the user username exists
                if (_databaseConnection.AppUsers.Any(n => n.Username.ToLower() == username &&
                                                          n.HasSocialMediaLogin == false))
                {
                    ViewBag["display"] = NotificationType.Error.ToString();
                    ViewData["Message"] =
                        "A user with the same Username already exist, try another Credential!";
                    return View(model);
                }
                if (_databaseConnection.AppUsers.Any(
                    n => n.Username.ToLower() == username && n.HasSocialMediaLogin))
                {
                    ViewBag["display"] = NotificationType.Error.ToString();
                    ViewData["Message"] =
                        "A user with the same Username already exist via Social Media Login, try another Credential!";
                    return View(model);
                }
                //invalid user becuase the user email exists
                if (_databaseConnection.AppUsers.Any(
                    n => n.Email.ToLower() == email && n.HasSocialMediaLogin == false))
                {
                    ViewBag["display"] = NotificationType.Error.ToString();
                    ViewData["Message"] = "A user with the same Email already exist, try another Credential!";
                    return View(model);
                }
                if (_databaseConnection.AppUsers.Any(
                    n => n.Email.ToLower() == email && n.HasSocialMediaLogin))
                {
                    ViewBag["display"] = NotificationType.Error.ToString();
                    ViewData["Message"] =
                        "A user with the same Email already exist via Social Media Login, try another Credential!";
                    return View(model);
                }
                //valid user
                _databaseConnection.AppUsers.Add(appUser);
                _databaseConnection.SaveChanges();
                appUser.Role = _databaseConnection.Roles.Find(appUser.RoleId);

                //define acceskeys and save transactions
                var accessKey = new AppUserAccessKey
                {
                    PasswordAccessCode = new Md5Ecryption().RandomString(15),
                    AccountActivationAccessCode = new Md5Ecryption().RandomString(20),
                    CreatedBy = appUser.AppUserId,
                    LastModifiedBy = appUser.AppUserId,
                    DateCreated = DateTime.Now,
                    DateLastModified = DateTime.Now,
                    ExpiryDate = DateTime.Now.AddDays(1),
                    AppUserId = appUser.AppUserId
                };
                _databaseConnection.AppUserAccessKeys.Add(accessKey);
                _databaseConnection.SaveChanges();

                //determine access logs save transaction
                ViewData["Message"] = "You have successfully registered, Check your email to confirm your account!";
                ViewBag["display"] = NotificationType.Success.ToString();
                //new SendEmailMessage().SendNewUserEmailMessage(userTransport);

                return View(appUser);
            }
            catch (Exception ex)
            {
                ViewData["Message"] = "Request is unavailable at the moment, Try again Later!";
                ViewBag["display"] = NotificationType.Error.ToString();
                return View(model);
            }
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login([FromBody] AccountModel model)
        {
            var access = new AccessLog();
            AppUser userExist = null;
            try
            {
                //for platform login
                if (model != null && model.LoginType == LoginType.Platform.ToString())
                {
                    var loginName = model.LoginName.ToLower();
                    userExist = _databaseConnection.AppUsers.Include(n => n.Role).SingleOrDefault(
                        n => n.Email.ToLower() == loginName || n.Username == loginName);
                    if (userExist == null)
                    {
                        ViewData["Message"] = "The Account does not exist,Check and Try again!";
                        ViewBag["display"] = NotificationType.Error.ToString();
                    }
                    else
                    {
                        if (userExist.HasSocialMediaLogin == false)
                        {
                            if (userExist.Status == UserStatus.Inactive.ToString())
                            {
                                ViewData["Message"] =
                                    "You are yet to activate your account from the the link sent to your " +
                                    "email when you created the account!";
                                ViewBag["display"] = NotificationType.Error.ToString();
                                return View(model);
                            }


                            var passwordCorrect = userExist != null &&
                                                  new Hashing().ValidatePassword(model.Password,
                                                      userExist.ConfirmPassword);
                            if (passwordCorrect == false)
                                if (userExist != null)
                                {
                                    ViewData["Message"] = "Dear " + userExist.Name +
                                                          " your Password is Incorrect, Check and Try again!";
                                    ViewBag["display"] = NotificationType.Error.ToString();
                                    return View(model);
                                }
                            if (passwordCorrect)
                            {
                                ViewData["Message"] = "Dear " + userExist.Name + ", You have successfully logged in!";
                                ViewBag["display"] = NotificationType.Error.ToString();
                                return View(model);
                            }
                        }
                        else
                        {
                            ViewData["Message"] =
                                "This Account is Social Media Enabled, Use the Appropriate social Media to Sign In!";
                            ViewBag["display"] = NotificationType.Error.ToString();
                            return View(model);
                        }
                    }
                }
                else
                {
                    var loginName = model.LoginName.ToLower();
                    userExist = _databaseConnection.AppUsers.Include(n => n.Role).SingleOrDefault(
                        n => n.Email.ToLower() == loginName || n.Username == loginName);


                    if (userExist == null)
                    {
                        var appUser = new AppUser
                        {
                            Name = model.LoginName,
                            Mobile = model.Mobile,
                            Email = model.Email,
                            Username = model.Username,
                            Status = UserStatus.Active.ToString(),
                            Address = "Social Media",
                            BackgroundPicture = "photo1.jpg",
                            ProfilePicture = model.ProfilePicture,
                            Biography = "Social Media",
                            DateOfBirth = null,
                            Website = "Social Media",
                            RoleId = model.RoleId,
                            DateCreated = DateTime.Now,
                            DateLastModified = DateTime.Now,
                            CreatedBy = null,
                            LastModifiedBy = null,
                            HasSocialMediaLogin = true,
                            AccountType = model.LoginType,
                            Role = _databaseConnection.Roles.Find(model.RoleId)
                        };
                        if (string.IsNullOrEmpty(appUser.Password))
                        {
                            appUser.Password = new Hashing().HashPassword(new Md5Ecryption().RandomString(5));
                            appUser.ConfirmPassword = appUser.Password;
                        }

                        _databaseConnection.AppUsers.Add(appUser);
                        _databaseConnection.SaveChanges();
                        if (appUser.AppUserId > 0)
                        {
                            //define acceskeys and save transactions
                            var accessKey = new AppUserAccessKey
                            {
                                PasswordAccessCode = new Md5Ecryption().RandomString(15),
                                AccountActivationAccessCode = new Md5Ecryption().RandomString(20),
                                CreatedBy = appUser.AppUserId,
                                LastModifiedBy = appUser.AppUserId,
                                DateCreated = DateTime.Now,
                                DateLastModified = DateTime.Now,
                                ExpiryDate = DateTime.Now.AddDays(1),
                                AppUserId = appUser.AppUserId
                            };
                            _databaseConnection.AppUserAccessKeys.Add(accessKey);
                            _databaseConnection.SaveChanges();
                            //create and populate user transport object
                            // new SendEmailMessage().SendNewUserSoialEmailMessage(appUser);
                            return View(model);
                        }
                    }
                    else
                    {
                        if (!userExist.HasSocialMediaLogin)
                        {
                            ViewData["Message"] =
                                "This Account is a Platform Enabled Account, Use your correct username and password to sign in!";
                            ViewBag["display"] = NotificationType.Error.ToString();
                            return View(model);
                        }
                        userExist.ProfilePicture = model.ProfilePicture;

                        //update user
                        _databaseConnection.Entry(userExist).State = EntityState.Modified;
                        _databaseConnection.SaveChanges();

                        access.Message = "Dear " + userExist.Name + " You have successfully logged in!";
                        ViewBag["display"] = NotificationType.Error.ToString();
                        return View(model);
                    }
                    return View(model);
                }
                return View(model);
            }

            catch (Exception ex)
            {
                ViewData["Message"] = "Request Unavailable, Try again later!";
                ViewBag["display"] = NotificationType.Error.ToString();
                return View(model);
            }
            
        }
    }
}