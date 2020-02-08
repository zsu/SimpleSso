# SimpleSso
Simple SSO Solution.

# Usage
1. Run Db/Schema.sql to create table in Db.
2. Create token in source application and redirect to target by appending the token in url. Default tokenLifeTime is 30 seconds and can be override.
```xml
  * var sso = new SsoManager(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
  * var token = sso.CreateToken("John", "SourceWeb");
  * return Redirect($"https://localhost:44366/Home/Login/?{SsoManager.QueryStringToken}={token}");
```
3. Verify token in target application
```xml
  * var sso = new SsoManager(_configuration.GetConnectionString("DefaultConnection"));
  * var loginId = sso.VerifyToken(Request.Query[SsoManager.QueryStringToken]);
  if(!string.loginId)
  {
      //Manually signin the user in the current application
  }
```
# License
All source code is licensed under MIT license - http://www.opensource.org/licenses/mit-license.php
