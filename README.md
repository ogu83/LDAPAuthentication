# LDAPAuthentication

A LDAP Login Mechanism demo via secure WCF Service also authenticated with Custom HttpModule

# Technology
-	Visual Studio 2012
-	.NET Framework 4.5.1
-	SQL Express
-	MVC 5: Authentication Forms
-	WCF 4: wsHttpBinding, Transport with Windows Credential, Entity Framework 6.x

# Web Application & WCF Service
Login Application is a MVC application and has method “public ActionResult Login(LoginModel model, string returnurl)”. Any application in intranet could call this Post method with return URL. If the credentials provided by the user at the login screen is authenticated by WCF Service according to the Active Directory (LDAP) could redirected to the return URL, otherwise “Access Denied” message will be presented and login will be rejected.
WCF Service is using HttpContextAuthorizationPolicy, also any intranet application need to use WCF Service including this login Web App should Process Authentication by HttpAuthenticationModule.
