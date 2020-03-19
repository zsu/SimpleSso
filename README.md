# SimpleSso
Simple SSO Solution.
# NuGet
```xml
Install-Package SimpleSso
```
# Usage
1. Run Db/Schema.sql to create table in Db.
2. Create token in source application and redirect to target by appending the token in url. Default tokenLifeTime is 30 seconds and can be overridden.
```xml
  var sso = new SsoManager(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
  var token = sso.CreateToken("John", "SourceWeb");
  return Redirect($"https://localhost:44366/Home/Login/?{SsoManager.QueryStringToken}={token}");
```
3. Verify token in target application
```xml
  var sso = new SsoManager(_configuration.GetConnectionString("DefaultConnection"));
  var queryString=Microsoft.AspNetCore.WebUtilities.QueryHelpers.ParseQuery(returnUrl?.Substring(returnUrl?.IndexOf("?")??0));
  var loginId = queryString?.Count()>0?sso.VerifyToken(queryString[SsoManager.QueryStringToken]):null;
  if(!string.IsNullOrWhiteSpace(loginId))
  {
      //Manually signin the user in the current application
  }
```
# License
All source code is licensed under MIT license - http://www.opensource.org/licenses/mit-license.php
