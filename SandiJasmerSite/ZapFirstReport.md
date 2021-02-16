
# ZAP Scanning Report

Generated on Mon, 15 Feb 2021 13:19:36


## Summary of Alerts

| Risk Level | Number of Alerts |
| --- | --- |
| High | 1 |
| Medium | 2 |
| Low | 10 |
| Informational | 5 |

## Alerts

| Name | Risk Level | Number of Instances |
| --- | --- | --- |
| Cross Site Scripting (Reflected) | High | 2 |
| Format String Error | Medium | 1 |
| X-Frame-Options Header Not Set | Medium | 17 |
| Cookie Without Secure Flag | Low | 2 |
| Incomplete or No Cache-control and Pragma HTTP Header Set | Low | 55 |
| Server Leaks Information via "X-Powered-By" HTTP Response Header Field(s) | Low | 26 |
| X-Content-Type-Options Header Missing | Low | 29 |
| Charset Mismatch  | Informational | 1 |
| Information Disclosure - Suspicious Comments | Informational | 4 |
| Loosely Scoped Cookie | Informational | 4 |
| Timestamp Disclosure - Unix | Informational | 108 |

## Alert Detail



  


### Cross Site Scripting (Reflected)
##### High (Low)

  


#### Description
<p>Cross-site Scripting (XSS) is an attack technique that involves echoing attacker-supplied code into a user's browser instance. A browser instance can be a standard web browser client, or a browser object embedded in a software product such as the browser within WinAmp, an RSS reader, or an email client. The code itself is usually written in HTML/JavaScript, but may also extend to VBScript, ActiveX, Java, Flash, or any other browser-supported technology.</p><p>When an attacker gets a user's browser to execute his/her code, the code will run within the security context (or zone) of the hosting web site. With this level of privilege, the code has the ability to read, modify and transmit any sensitive data accessible by the browser. A Cross-site Scripted user could have his/her account hijacked (cookie theft), their browser redirected to another location, or possibly shown fraudulent content delivered by the web site they are visiting. Cross-site Scripting attacks essentially compromise the trust relationship between a user and the web site. Applications utilizing browser object instances which load content from the file system may execute code under the local machine zone allowing for system compromise.</p><p></p><p>There are three types of Cross-site Scripting attacks: non-persistent, persistent and DOM-based.</p><p>Non-persistent attacks and DOM-based attacks require a user to either visit a specially crafted link laced with malicious code, or visit a malicious web page containing a web form, which when posted to the vulnerable site, will mount the attack. Using a malicious form will oftentimes take place when the vulnerable resource only accepts HTTP POST requests. In such a case, the form can be submitted automatically, without the victim's knowledge (e.g. by using JavaScript). Upon clicking on the malicious link or submitting the malicious form, the XSS payload will get echoed back and will get interpreted by the user's browser and execute. Another technique to send almost arbitrary requests (GET and POST) is by using an embedded client, such as Adobe Flash.</p><p>Persistent attacks occur when the malicious code is submitted to a web site where it's stored for a period of time. Examples of an attacker's favorite targets often include message board posts, web mail messages, and web chat software. The unsuspecting user is not required to interact with any additional site/link (e.g. an attacker site or a malicious link sent via email), just simply view the web page containing the code.</p>

  

* URL: [https://localhost:44308/Account/LogIn](https://localhost:44308/Account/LogIn)
  
  
  * Method: `POST`
  
  
  * Parameter: `RememberMe`
  
  
  * Attack: `<script>alert(1);</script>`
  
  
  * Evidence: `<script>alert(1);</script>`
  
  
  
* URL: [https://localhost:44308/Account/LogIn?returnUrl=%2FHome%2FStories](https://localhost:44308/Account/LogIn?returnUrl=%2FHome%2FStories)
  
  
  * Method: `POST`
  
  
  * Parameter: `RememberMe`
  
  
  * Attack: `<script>alert(1);</script>`
  
  
  * Evidence: `<script>alert(1);</script>`
  
  
  
  

Instances: 2

### Solution
<p>Phase: Architecture and Design</p><p>Use a vetted library or framework that does not allow this weakness to occur or provides constructs that make this weakness easier to avoid.</p><p>Examples of libraries and frameworks that make it easier to generate properly encoded output include Microsoft's Anti-XSS library, the OWASP ESAPI Encoding module, and Apache Wicket.</p><p></p><p>Phases: Implementation; Architecture and Design</p><p>Understand the context in which your data will be used and the encoding that will be expected. This is especially important when transmitting data between different components, or when generating outputs that can contain multiple encodings at the same time, such as web pages or multi-part mail messages. Study all expected communication protocols and data representations to determine the required encoding strategies.</p><p>For any data that will be output to another web page, especially any data that was received from external inputs, use the appropriate encoding on all non-alphanumeric characters.</p><p>Consult the XSS Prevention Cheat Sheet for more details on the types of encoding and escaping that are needed.</p><p></p><p>Phase: Architecture and Design</p><p>For any security checks that are performed on the client side, ensure that these checks are duplicated on the server side, in order to avoid CWE-602. Attackers can bypass the client-side checks by modifying values after the checks have been performed, or by changing the client to remove the client-side checks entirely. Then, these modified values would be submitted to the server.</p><p></p><p>If available, use structured mechanisms that automatically enforce the separation between data and code. These mechanisms may be able to provide the relevant quoting, encoding, and validation automatically, instead of relying on the developer to provide this capability at every point where output is generated.</p><p></p><p>Phase: Implementation</p><p>For every web page that is generated, use and specify a character encoding such as ISO-8859-1 or UTF-8. When an encoding is not specified, the web browser may choose a different encoding by guessing which encoding is actually being used by the web page. This can cause the web browser to treat certain sequences as special, opening up the client to subtle XSS attacks. See CWE-116 for more mitigations related to encoding/escaping.</p><p></p><p>To help mitigate XSS attacks against the user's session cookie, set the session cookie to be HttpOnly. In browsers that support the HttpOnly feature (such as more recent versions of Internet Explorer and Firefox), this attribute can prevent the user's session cookie from being accessible to malicious client-side scripts that use document.cookie. This is not a complete solution, since HttpOnly is not supported by all browsers. More importantly, XMLHTTPRequest and other powerful browser technologies provide read access to HTTP headers, including the Set-Cookie header in which the HttpOnly flag is set.</p><p></p><p>Assume all input is malicious. Use an "accept known good" input validation strategy, i.e., use an allow list of acceptable inputs that strictly conform to specifications. Reject any input that does not strictly conform to specifications, or transform it into something that does. Do not rely exclusively on looking for malicious or malformed inputs (i.e., do not rely on a deny list). However, deny lists can be useful for detecting potential attacks or determining which inputs are so malformed that they should be rejected outright.</p><p></p><p>When performing input validation, consider all potentially relevant properties, including length, type of input, the full range of acceptable values, missing or extra inputs, syntax, consistency across related fields, and conformance to business rules. As an example of business rule logic, "boat" may be syntactically valid because it only contains alphanumeric characters, but it is not valid if you are expecting colors such as "red" or "blue."</p><p></p><p>Ensure that you perform input validation at well-defined interfaces within the application. This will help protect the application even if a component is reused or moved elsewhere.</p>

### Other information
<p>Raised with LOW confidence as the Content-Type is not HTML</p>

### Reference
* http://projects.webappsec.org/Cross-Site-Scripting
* http://cwe.mitre.org/data/definitions/79.html

  
#### CWE Id : 79

#### WASC Id : 8

#### Source ID : 1

  

  

### Format String Error
##### Medium (Medium)

  


#### Description
<p>A Format String error occurs when the submitted data of an input string is evaluated as a command by the application. </p>

  

* URL: [https://localhost:44308/Home/Stories](https://localhost:44308/Home/Stories)
  
  
  * Method: `POST`
  
  
  * Parameter: `Title`
  
  
  * Attack: `ZAP %1!s%2!s%3!s%4!s%5!s%6!s%7!s%8!s%9!s%10!s%11!s%12!s%13!s%14!s%15!s%16!s%17!s%18!s%19!s%20!s%21!n%22!n%23!n%24!n%25!n%26!n%27!n%28!n%29!n%30!n%31!n%32!n%33!n%34!n%35!n%36!n%37!n%38!n%39!n%40!n
`
  
  
  
  

Instances: 1

### Solution
<p>Rewrite the background program using proper deletion of bad character strings.  This will require a recompile of the background executable.</p>

### Other information
<p>Potential Format String Error.  The script closed the connection on a microsoft format string error</p>

### Reference
* https://owasp.org/www-community/attacks/Format_string_attack

  
#### CWE Id : 134

#### WASC Id : 6

#### Source ID : 1

  

  

### X-Frame-Options Header Not Set
##### Medium (Medium)

  


#### Description
<p>X-Frame-Options header is not included in the HTTP response to protect against 'ClickJacking' attacks.</p>

  

* URL: [https://localhost:44308/Account/Login?ReturnUrl=%2FHome%2FStories](https://localhost:44308/Account/Login?ReturnUrl=%2FHome%2FStories)
  
  
  * Method: `GET`
  
  
  * Parameter: `X-Frame-Options`
  
  
  
* URL: [https://localhost:44308/FanClub](https://localhost:44308/FanClub)
  
  
  * Method: `GET`
  
  
  * Parameter: `X-Frame-Options`
  
  
  
* URL: [https://localhost:44308/Media/Resources](https://localhost:44308/Media/Resources)
  
  
  * Method: `GET`
  
  
  * Parameter: `X-Frame-Options`
  
  
  
* URL: [https://localhost:44308/](https://localhost:44308/)
  
  
  * Method: `GET`
  
  
  * Parameter: `X-Frame-Options`
  
  
  
* URL: [https://localhost:44308/Account/LogIn](https://localhost:44308/Account/LogIn)
  
  
  * Method: `GET`
  
  
  * Parameter: `X-Frame-Options`
  
  
  
* URL: [https://localhost:44308/Media/Social](https://localhost:44308/Media/Social)
  
  
  * Method: `GET`
  
  
  * Parameter: `X-Frame-Options`
  
  
  
* URL: [https://localhost:44308/Account/Register](https://localhost:44308/Account/Register)
  
  
  * Method: `POST`
  
  
  * Parameter: `X-Frame-Options`
  
  
  
* URL: [https://localhost:44308/Home/About](https://localhost:44308/Home/About)
  
  
  * Method: `GET`
  
  
  * Parameter: `X-Frame-Options`
  
  
  
* URL: [https://localhost:44308/FanClub/Quiz](https://localhost:44308/FanClub/Quiz)
  
  
  * Method: `GET`
  
  
  * Parameter: `X-Frame-Options`
  
  
  
* URL: [https://localhost:44308/Media](https://localhost:44308/Media)
  
  
  * Method: `GET`
  
  
  * Parameter: `X-Frame-Options`
  
  
  
* URL: [https://localhost:44308/Home/AllStories](https://localhost:44308/Home/AllStories)
  
  
  * Method: `GET`
  
  
  * Parameter: `X-Frame-Options`
  
  
  
* URL: [https://localhost:44308/Account/LogIn](https://localhost:44308/Account/LogIn)
  
  
  * Method: `POST`
  
  
  * Parameter: `X-Frame-Options`
  
  
  
* URL: [https://localhost:44308/Account/LogIn?returnUrl=%2FHome%2FStories](https://localhost:44308/Account/LogIn?returnUrl=%2FHome%2FStories)
  
  
  * Method: `POST`
  
  
  * Parameter: `X-Frame-Options`
  
  
  
* URL: [https://localhost:44308/FanClub/Quiz](https://localhost:44308/FanClub/Quiz)
  
  
  * Method: `POST`
  
  
  * Parameter: `X-Frame-Options`
  
  
  
* URL: [https://localhost:44308/Home/Stories](https://localhost:44308/Home/Stories)
  
  
  * Method: `POST`
  
  
  * Parameter: `X-Frame-Options`
  
  
  
* URL: [https://localhost:44308/Home/Stories](https://localhost:44308/Home/Stories)
  
  
  * Method: `GET`
  
  
  * Parameter: `X-Frame-Options`
  
  
  
* URL: [https://localhost:44308/Home/Privacy](https://localhost:44308/Home/Privacy)
  
  
  * Method: `GET`
  
  
  * Parameter: `X-Frame-Options`
  
  
  
  

Instances: 17

### Solution
<p>Most modern Web browsers support the X-Frame-Options HTTP header. Ensure it's set on all web pages returned by your site (if you expect the page to be framed only by pages on your server (e.g. it's part of a FRAMESET) then you'll want to use SAMEORIGIN, otherwise if you never expect the page to be framed, you should use DENY. Alternatively consider implementing Content Security Policy's "frame-ancestors" directive. </p>

### Reference
* https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/X-Frame-Options

  
#### CWE Id : 16

#### WASC Id : 15

#### Source ID : 3

  

  

### Cookie Without Secure Flag
##### Low (Medium)

  


#### Description
<p>A cookie has been set without the secure flag, which means that the cookie can be accessed via unencrypted connections.</p>

  

* URL: [https://localhost:44308/Account/Register](https://localhost:44308/Account/Register)
  
  
  * Method: `GET`
  
  
  * Parameter: `.AspNetCore.Antiforgery.Ya7HB32Ca-Y`
  
  
  * Evidence: `Set-Cookie: .AspNetCore.Antiforgery.Ya7HB32Ca-Y`
  
  
  
* URL: [https://localhost:44308/Account/Login](https://localhost:44308/Account/Login)
  
  
  * Method: `GET`
  
  
  * Parameter: `.AspNetCore.Antiforgery.Ya7HB32Ca-Y`
  
  
  * Evidence: `Set-Cookie: .AspNetCore.Antiforgery.Ya7HB32Ca-Y`
  
  
  
  

Instances: 2

### Solution
<p>Whenever a cookie contains sensitive information or is a session token, then it should always be passed using an encrypted channel. Ensure that the secure flag is set for cookies containing such sensitive information.</p>

### Reference
* https://owasp.org/www-project-web-security-testing-guide/v41/4-Web_Application_Security_Testing/06-Session_Management_Testing/02-Testing_for_Cookies_Attributes.html

  
#### CWE Id : 614

#### WASC Id : 13

#### Source ID : 3

  

  

### Incomplete or No Cache-control and Pragma HTTP Header Set
##### Low (Medium)

  


#### Description
<p>The cache-control and pragma HTTP header have not been set properly or are missing allowing the browser and proxies to cache content.</p>

  

* URL: [https://aus5.mozilla.org/update/3/SystemAddons/85.0.2/20210208133944/WINNT_x86_64-msvc-x64/en-US/release/Windows_NT%2010.0.0.0.19041.746%20(x64)/default/default/update.xml](https://aus5.mozilla.org/update/3/SystemAddons/85.0.2/20210208133944/WINNT_x86_64-msvc-x64/en-US/release/Windows_NT%2010.0.0.0.19041.746%20(x64)/default/default/update.xml)
  
  
  * Method: `GET`
  
  
  * Parameter: `Cache-Control`
  
  
  * Evidence: `public, max-age=90`
  
  
  
  

Instances: 1

### Solution
<p>Whenever possible ensure the cache-control HTTP header is set with no-cache, no-store, must-revalidate; and that the pragma HTTP header is set with no-cache.</p>

### Reference
* https://cheatsheetseries.owasp.org/cheatsheets/Session_Management_Cheat_Sheet.html#web-content-caching

  
#### CWE Id : 525

#### WASC Id : 13

#### Source ID : 3

  

  

### Incomplete or No Cache-control and Pragma HTTP Header Set
##### Low (Medium)

  


#### Description
<p>The cache-control and pragma HTTP header have not been set properly or are missing allowing the browser and proxies to cache content.</p>

  

* URL: [https://localhost:44308/Home/Privacy](https://localhost:44308/Home/Privacy)
  
  
  * Method: `GET`
  
  
  * Parameter: `Cache-Control`
  
  
  
* URL: [https://localhost:44308/Account/LogIn?returnUrl=%2FHome%2FStories](https://localhost:44308/Account/LogIn?returnUrl=%2FHome%2FStories)
  
  
  * Method: `POST`
  
  
  * Parameter: `Cache-Control`
  
  
  * Evidence: `no-cache, no-store`
  
  
  
* URL: [https://localhost:44308/Account/Login?ReturnUrl=%2FHome%2FStories](https://localhost:44308/Account/Login?ReturnUrl=%2FHome%2FStories)
  
  
  * Method: `GET`
  
  
  * Parameter: `Cache-Control`
  
  
  * Evidence: `no-cache, no-store`
  
  
  
* URL: [https://localhost:44308/FanClub/Quiz](https://localhost:44308/FanClub/Quiz)
  
  
  * Method: `POST`
  
  
  * Parameter: `Cache-Control`
  
  
  * Evidence: `no-cache, no-store`
  
  
  
* URL: [https://localhost:44308/Home/Stories](https://localhost:44308/Home/Stories)
  
  
  * Method: `POST`
  
  
  * Parameter: `Cache-Control`
  
  
  * Evidence: `no-cache, no-store`
  
  
  
* URL: [https://localhost:44308/Account/Register](https://localhost:44308/Account/Register)
  
  
  * Method: `POST`
  
  
  * Parameter: `Cache-Control`
  
  
  * Evidence: `no-cache, no-store`
  
  
  
* URL: [https://localhost:44308/Media](https://localhost:44308/Media)
  
  
  * Method: `GET`
  
  
  * Parameter: `Cache-Control`
  
  
  
* URL: [https://localhost:44308/Account/Register](https://localhost:44308/Account/Register)
  
  
  * Method: `GET`
  
  
  * Parameter: `Cache-Control`
  
  
  * Evidence: `no-cache, no-store`
  
  
  
* URL: [https://localhost:44308/Account/LogIn](https://localhost:44308/Account/LogIn)
  
  
  * Method: `POST`
  
  
  * Parameter: `Cache-Control`
  
  
  * Evidence: `no-cache, no-store`
  
  
  
* URL: [https://localhost:44308/Home/Stories](https://localhost:44308/Home/Stories)
  
  
  * Method: `GET`
  
  
  * Parameter: `Cache-Control`
  
  
  * Evidence: `no-cache, no-store`
  
  
  
* URL: [https://localhost:44308/Home/AllStories](https://localhost:44308/Home/AllStories)
  
  
  * Method: `GET`
  
  
  * Parameter: `Cache-Control`
  
  
  * Evidence: `no-cache, no-store`
  
  
  
* URL: [https://localhost:44308/lib/bootstrap/dist/css/bootstrap.min.css](https://localhost:44308/lib/bootstrap/dist/css/bootstrap.min.css)
  
  
  * Method: `GET`
  
  
  * Parameter: `Cache-Control`
  
  
  
* URL: [https://localhost:44308/FanClub/Quiz](https://localhost:44308/FanClub/Quiz)
  
  
  * Method: `GET`
  
  
  * Parameter: `Cache-Control`
  
  
  * Evidence: `no-cache, no-store`
  
  
  
* URL: [https://localhost:44308/Account/Login](https://localhost:44308/Account/Login)
  
  
  * Method: `GET`
  
  
  * Parameter: `Cache-Control`
  
  
  * Evidence: `no-cache, no-store`
  
  
  
* URL: [https://localhost:44308/](https://localhost:44308/)
  
  
  * Method: `GET`
  
  
  * Parameter: `Cache-Control`
  
  
  
* URL: [https://localhost:44308/Media/Social](https://localhost:44308/Media/Social)
  
  
  * Method: `GET`
  
  
  * Parameter: `Cache-Control`
  
  
  
* URL: [https://localhost:44308/FanClub](https://localhost:44308/FanClub)
  
  
  * Method: `GET`
  
  
  * Parameter: `Cache-Control`
  
  
  
* URL: [https://localhost:44308/Account/LogIn](https://localhost:44308/Account/LogIn)
  
  
  * Method: `GET`
  
  
  * Parameter: `Cache-Control`
  
  
  * Evidence: `no-cache, no-store`
  
  
  
* URL: [https://localhost:44308/Home/About](https://localhost:44308/Home/About)
  
  
  * Method: `GET`
  
  
  * Parameter: `Cache-Control`
  
  
  
* URL: [https://localhost:44308/Media/Resources](https://localhost:44308/Media/Resources)
  
  
  * Method: `GET`
  
  
  * Parameter: `Cache-Control`
  
  
  
  

Instances: 21

### Solution
<p>Whenever possible ensure the cache-control HTTP header is set with no-cache, no-store, must-revalidate; and that the pragma HTTP header is set with no-cache.</p>

### Reference
* https://cheatsheetseries.owasp.org/cheatsheets/Session_Management_Cheat_Sheet.html#web-content-caching

  
#### CWE Id : 525

#### WASC Id : 13

#### Source ID : 3

  

  

### Incomplete or No Cache-control and Pragma HTTP Header Set
##### Low (Medium)

  


#### Description
<p>The cache-control and pragma HTTP header have not been set properly or are missing allowing the browser and proxies to cache content.</p>

  

* URL: [https://snippets.cdn.mozilla.net/us-west/bundles-pregen/Firefox/en-us/default.json](https://snippets.cdn.mozilla.net/us-west/bundles-pregen/Firefox/en-us/default.json)
  
  
  * Method: `GET`
  
  
  * Parameter: `Cache-Control`
  
  
  * Evidence: `max-age=600`
  
  
  
  

Instances: 1

### Solution
<p>Whenever possible ensure the cache-control HTTP header is set with no-cache, no-store, must-revalidate; and that the pragma HTTP header is set with no-cache.</p>

### Reference
* https://cheatsheetseries.owasp.org/cheatsheets/Session_Management_Cheat_Sheet.html#web-content-caching

  
#### CWE Id : 525

#### WASC Id : 13

#### Source ID : 3

  

  

### Incomplete or No Cache-control and Pragma HTTP Header Set
##### Low (Medium)

  


#### Description
<p>The cache-control and pragma HTTP header have not been set properly or are missing allowing the browser and proxies to cache content.</p>

  

* URL: [https://firefox.settings.services.mozilla.com/v1/buckets/blocklists/collections/plugins?_expected=1603126502200](https://firefox.settings.services.mozilla.com/v1/buckets/blocklists/collections/plugins?_expected=1603126502200)
  
  
  * Method: `GET`
  
  
  * Parameter: `Cache-Control`
  
  
  * Evidence: `no-cache, no-store`
  
  
  
* URL: [https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/search-default-override-allowlist?_expected=1595254618540](https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/search-default-override-allowlist?_expected=1595254618540)
  
  
  * Method: `GET`
  
  
  * Parameter: `Cache-Control`
  
  
  * Evidence: `no-cache, no-store`
  
  
  
* URL: [https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/top-sites?_expected=1611838808382](https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/top-sites?_expected=1611838808382)
  
  
  * Method: `GET`
  
  
  * Parameter: `Cache-Control`
  
  
  * Evidence: `no-cache, no-store`
  
  
  
* URL: [https://firefox.settings.services.mozilla.com/v1/buckets/security-state/collections/intermediates/changeset?_expected=1613419113815&_since=%221612576697229%22](https://firefox.settings.services.mozilla.com/v1/buckets/security-state/collections/intermediates/changeset?_expected=1613419113815&_since=%221612576697229%22)
  
  
  * Method: `GET`
  
  
  * Parameter: `Cache-Control`
  
  
  
* URL: [https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/password-recipes?_expected=1600889167888](https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/password-recipes?_expected=1600889167888)
  
  
  * Method: `GET`
  
  
  * Parameter: `Cache-Control`
  
  
  * Evidence: `no-cache, no-store`
  
  
  
* URL: [https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/anti-tracking-url-decoration?_expected=1564511755134](https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/anti-tracking-url-decoration?_expected=1564511755134)
  
  
  * Method: `GET`
  
  
  * Parameter: `Cache-Control`
  
  
  * Evidence: `no-cache, no-store`
  
  
  
* URL: [https://firefox.settings.services.mozilla.com/v1/buckets/monitor/collections/changes/records?collection=whats-new-panel&bucket=main](https://firefox.settings.services.mozilla.com/v1/buckets/monitor/collections/changes/records?collection=whats-new-panel&bucket=main)
  
  
  * Method: `GET`
  
  
  * Parameter: `Cache-Control`
  
  
  * Evidence: `max-age=60`
  
  
  
* URL: [https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/language-dictionaries?_expected=1569410800356](https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/language-dictionaries?_expected=1569410800356)
  
  
  * Method: `GET`
  
  
  * Parameter: `Cache-Control`
  
  
  * Evidence: `no-cache, no-store`
  
  
  
* URL: [https://firefox.settings.services.mozilla.com/v1/buckets/monitor/collections/changes/records?collection=message-groups&bucket=main](https://firefox.settings.services.mozilla.com/v1/buckets/monitor/collections/changes/records?collection=message-groups&bucket=main)
  
  
  * Method: `GET`
  
  
  * Parameter: `Cache-Control`
  
  
  * Evidence: `max-age=60`
  
  
  
* URL: [https://firefox.settings.services.mozilla.com/v1/buckets/monitor/collections/changes/records?collection=cfr&bucket=main](https://firefox.settings.services.mozilla.com/v1/buckets/monitor/collections/changes/records?collection=cfr&bucket=main)
  
  
  * Method: `GET`
  
  
  * Parameter: `Cache-Control`
  
  
  * Evidence: `max-age=60`
  
  
  
* URL: [https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/whats-new-panel/changeset?_expected=1611670765047](https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/whats-new-panel/changeset?_expected=1611670765047)
  
  
  * Method: `GET`
  
  
  * Parameter: `Cache-Control`
  
  
  
* URL: [https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/pioneer-study-addons-v1/changeset?_expected=1607042143590](https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/pioneer-study-addons-v1/changeset?_expected=1607042143590)
  
  
  * Method: `GET`
  
  
  * Parameter: `Cache-Control`
  
  
  
* URL: [https://firefox.settings.services.mozilla.com/v1/buckets/monitor/collections/changes/records?collection=partitioning-exempt-urls&bucket=main](https://firefox.settings.services.mozilla.com/v1/buckets/monitor/collections/changes/records?collection=partitioning-exempt-urls&bucket=main)
  
  
  * Method: `GET`
  
  
  * Parameter: `Cache-Control`
  
  
  * Evidence: `max-age=60`
  
  
  
* URL: [https://firefox.settings.services.mozilla.com/v1/buckets/security-state/collections/onecrl/changeset?_expected=1612908330359&_since=%221612664984721%22](https://firefox.settings.services.mozilla.com/v1/buckets/security-state/collections/onecrl/changeset?_expected=1612908330359&_since=%221612664984721%22)
  
  
  * Method: `GET`
  
  
  * Parameter: `Cache-Control`
  
  
  
* URL: [https://firefox.settings.services.mozilla.com/v1/buckets/blocklists/collections/addons-bloomfilters/changeset?_expected=1613392707497&_since=%221612658267016%22](https://firefox.settings.services.mozilla.com/v1/buckets/blocklists/collections/addons-bloomfilters/changeset?_expected=1613392707497&_since=%221612658267016%22)
  
  
  * Method: `GET`
  
  
  * Parameter: `Cache-Control`
  
  
  
* URL: [https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/public-suffix-list/changeset?_expected=1575468539758](https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/public-suffix-list/changeset?_expected=1575468539758)
  
  
  * Method: `GET`
  
  
  * Parameter: `Cache-Control`
  
  
  
* URL: [https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/partitioning-exempt-urls/changeset?_expected=1592906663254](https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/partitioning-exempt-urls/changeset?_expected=1592906663254)
  
  
  * Method: `GET`
  
  
  * Parameter: `Cache-Control`
  
  
  
* URL: [https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/cfr/changeset?_expected=1612312953148](https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/cfr/changeset?_expected=1612312953148)
  
  
  * Method: `GET`
  
  
  * Parameter: `Cache-Control`
  
  
  
* URL: [https://firefox.settings.services.mozilla.com/v1/buckets/blocklists/collections/gfx?_expected=1606146402211](https://firefox.settings.services.mozilla.com/v1/buckets/blocklists/collections/gfx?_expected=1606146402211)
  
  
  * Method: `GET`
  
  
  * Parameter: `Cache-Control`
  
  
  * Evidence: `no-cache, no-store`
  
  
  
* URL: [https://firefox.settings.services.mozilla.com/v1/buckets/pinning/collections/pins/changeset?_expected=1485794868067](https://firefox.settings.services.mozilla.com/v1/buckets/pinning/collections/pins/changeset?_expected=1485794868067)
  
  
  * Method: `GET`
  
  
  * Parameter: `Cache-Control`
  
  
  
  

Instances: 32

### Solution
<p>Whenever possible ensure the cache-control HTTP header is set with no-cache, no-store, must-revalidate; and that the pragma HTTP header is set with no-cache.</p>

### Reference
* https://cheatsheetseries.owasp.org/cheatsheets/Session_Management_Cheat_Sheet.html#web-content-caching

  
#### CWE Id : 525

#### WASC Id : 13

#### Source ID : 3

  

  

### Server Leaks Information via "X-Powered-By" HTTP Response Header Field(s)
##### Low (Medium)

  


#### Description
<p>The web/application server is leaking information via one or more "X-Powered-By" HTTP response headers. Access to such information may facilitate attackers identifying other frameworks/components your web application is reliant upon and the vulnerabilities such components may be subject to.</p>

  

* URL: [https://localhost:44308/Account/Login](https://localhost:44308/Account/Login)
  
  
  * Method: `GET`
  
  
  * Evidence: `X-Powered-By: ASP.NET`
  
  
  
* URL: [https://localhost:44308/js/site.js?v=4q1jwFhaPaZgr8WAUSrux6hAuh0XDg9kPS3xIVq36I0](https://localhost:44308/js/site.js?v=4q1jwFhaPaZgr8WAUSrux6hAuh0XDg9kPS3xIVq36I0)
  
  
  * Method: `GET`
  
  
  * Evidence: `X-Powered-By: ASP.NET`
  
  
  
* URL: [https://localhost:44308/css/site.css](https://localhost:44308/css/site.css)
  
  
  * Method: `GET`
  
  
  * Evidence: `X-Powered-By: ASP.NET`
  
  
  
* URL: [https://localhost:44308/lib/jquery/dist/jquery.min.js](https://localhost:44308/lib/jquery/dist/jquery.min.js)
  
  
  * Method: `GET`
  
  
  * Evidence: `X-Powered-By: ASP.NET`
  
  
  
* URL: [https://localhost:44308/Account/Register](https://localhost:44308/Account/Register)
  
  
  * Method: `GET`
  
  
  * Evidence: `X-Powered-By: ASP.NET`
  
  
  
* URL: [https://localhost:44308/Media](https://localhost:44308/Media)
  
  
  * Method: `GET`
  
  
  * Evidence: `X-Powered-By: ASP.NET`
  
  
  
* URL: [https://localhost:44308/FanClub/Quiz](https://localhost:44308/FanClub/Quiz)
  
  
  * Method: `GET`
  
  
  * Evidence: `X-Powered-By: ASP.NET`
  
  
  
* URL: [https://localhost:44308/Account/LogIn?returnUrl=%2FHome%2FStories](https://localhost:44308/Account/LogIn?returnUrl=%2FHome%2FStories)
  
  
  * Method: `POST`
  
  
  * Evidence: `X-Powered-By: ASP.NET`
  
  
  
* URL: [https://localhost:44308/Home/Stories](https://localhost:44308/Home/Stories)
  
  
  * Method: `GET`
  
  
  * Evidence: `X-Powered-By: ASP.NET`
  
  
  
* URL: [https://localhost:44308/FanClub/Quiz](https://localhost:44308/FanClub/Quiz)
  
  
  * Method: `POST`
  
  
  * Evidence: `X-Powered-By: ASP.NET`
  
  
  
* URL: [https://localhost:44308/lib/bootstrap/dist/css/bootstrap.min.css](https://localhost:44308/lib/bootstrap/dist/css/bootstrap.min.css)
  
  
  * Method: `GET`
  
  
  * Evidence: `X-Powered-By: ASP.NET`
  
  
  
* URL: [https://localhost:44308/Home/Stories](https://localhost:44308/Home/Stories)
  
  
  * Method: `POST`
  
  
  * Evidence: `X-Powered-By: ASP.NET`
  
  
  
* URL: [https://localhost:44308/Home/AllStories](https://localhost:44308/Home/AllStories)
  
  
  * Method: `GET`
  
  
  * Evidence: `X-Powered-By: ASP.NET`
  
  
  
* URL: [https://localhost:44308/lib/bootstrap/dist/js/bootstrap.bundle.min.js](https://localhost:44308/lib/bootstrap/dist/js/bootstrap.bundle.min.js)
  
  
  * Method: `GET`
  
  
  * Evidence: `X-Powered-By: ASP.NET`
  
  
  
* URL: [https://localhost:44308/Home/Privacy](https://localhost:44308/Home/Privacy)
  
  
  * Method: `GET`
  
  
  * Evidence: `X-Powered-By: ASP.NET`
  
  
  
* URL: [https://localhost:44308/FanClub](https://localhost:44308/FanClub)
  
  
  * Method: `GET`
  
  
  * Evidence: `X-Powered-By: ASP.NET`
  
  
  
* URL: [https://localhost:44308/Media/Resources](https://localhost:44308/Media/Resources)
  
  
  * Method: `GET`
  
  
  * Evidence: `X-Powered-By: ASP.NET`
  
  
  
* URL: [https://localhost:44308/Account/Login?ReturnUrl=%2FHome%2FStories](https://localhost:44308/Account/Login?ReturnUrl=%2FHome%2FStories)
  
  
  * Method: `GET`
  
  
  * Evidence: `X-Powered-By: ASP.NET`
  
  
  
* URL: [https://localhost:44308/sitemap.xml](https://localhost:44308/sitemap.xml)
  
  
  * Method: `GET`
  
  
  * Evidence: `X-Powered-By: ASP.NET`
  
  
  
* URL: [https://localhost:44308/Media/Social](https://localhost:44308/Media/Social)
  
  
  * Method: `GET`
  
  
  * Evidence: `X-Powered-By: ASP.NET`
  
  
  
  

Instances: 26

### Solution
<p>Ensure that your web server, application server, load balancer, etc. is configured to suppress "X-Powered-By" headers.</p>

### Reference
* http://blogs.msdn.com/b/varunm/archive/2013/04/23/remove-unwanted-http-response-headers.aspx
* http://www.troyhunt.com/2012/02/shhh-dont-let-your-response-headers.html

  
#### CWE Id : 200

#### WASC Id : 13

#### Source ID : 3

  

  

### X-Content-Type-Options Header Missing
##### Low (Medium)

  


#### Description
<p>The Anti-MIME-Sniffing header X-Content-Type-Options was not set to 'nosniff'. This allows older versions of Internet Explorer and Chrome to perform MIME-sniffing on the response body, potentially causing the response body to be interpreted and displayed as a content type other than the declared content type. Current (early 2014) and legacy versions of Firefox will use the declared content type (if one is set), rather than performing MIME-sniffing.</p>

  

* URL: [https://ftp.mozilla.org/pub/system-addons/reset-search-defaults/reset-search-defaults@mozilla.com-1.0.3-signed.xpi](https://ftp.mozilla.org/pub/system-addons/reset-search-defaults/reset-search-defaults@mozilla.com-1.0.3-signed.xpi)
  
  
  * Method: `GET`
  
  
  * Parameter: `X-Content-Type-Options`
  
  
  
  

Instances: 1

### Solution
<p>Ensure that the application/web server sets the Content-Type header appropriately, and that it sets the X-Content-Type-Options header to 'nosniff' for all web pages.</p><p>If possible, ensure that the end user uses a standards-compliant and modern web browser that does not perform MIME-sniffing at all, or that can be directed by the web application/web server to not perform MIME-sniffing.</p>

### Other information
<p>This issue still applies to error type pages (401, 403, 500, etc.) as those pages are often still affected by injection issues, in which case there is still concern for browsers sniffing pages away from their actual content type.</p><p>At "High" threshold this scan rule will not alert on client or server error responses.</p>

### Reference
* http://msdn.microsoft.com/en-us/library/ie/gg622941%28v=vs.85%29.aspx
* https://owasp.org/www-community/Security_Headers

  
#### CWE Id : 16

#### WASC Id : 15

#### Source ID : 3

  

  

### X-Content-Type-Options Header Missing
##### Low (Medium)

  


#### Description
<p>The Anti-MIME-Sniffing header X-Content-Type-Options was not set to 'nosniff'. This allows older versions of Internet Explorer and Chrome to perform MIME-sniffing on the response body, potentially causing the response body to be interpreted and displayed as a content type other than the declared content type. Current (early 2014) and legacy versions of Firefox will use the declared content type (if one is set), rather than performing MIME-sniffing.</p>

  

* URL: [https://localhost:44308/js/site.js?v=4q1jwFhaPaZgr8WAUSrux6hAuh0XDg9kPS3xIVq36I0](https://localhost:44308/js/site.js?v=4q1jwFhaPaZgr8WAUSrux6hAuh0XDg9kPS3xIVq36I0)
  
  
  * Method: `GET`
  
  
  * Parameter: `X-Content-Type-Options`
  
  
  
* URL: [https://localhost:44308/Account/Login](https://localhost:44308/Account/Login)
  
  
  * Method: `GET`
  
  
  * Parameter: `X-Content-Type-Options`
  
  
  
* URL: [https://localhost:44308/Account/LogIn?returnUrl=%2FHome%2FStories](https://localhost:44308/Account/LogIn?returnUrl=%2FHome%2FStories)
  
  
  * Method: `POST`
  
  
  * Parameter: `X-Content-Type-Options`
  
  
  
* URL: [https://localhost:44308/lib/bootstrap/dist/css/bootstrap.min.css](https://localhost:44308/lib/bootstrap/dist/css/bootstrap.min.css)
  
  
  * Method: `GET`
  
  
  * Parameter: `X-Content-Type-Options`
  
  
  
* URL: [https://localhost:44308/Media](https://localhost:44308/Media)
  
  
  * Method: `GET`
  
  
  * Parameter: `X-Content-Type-Options`
  
  
  
* URL: [https://localhost:44308/Home/AllStories](https://localhost:44308/Home/AllStories)
  
  
  * Method: `GET`
  
  
  * Parameter: `X-Content-Type-Options`
  
  
  
* URL: [https://localhost:44308/lib/jquery/dist/jquery.min.js](https://localhost:44308/lib/jquery/dist/jquery.min.js)
  
  
  * Method: `GET`
  
  
  * Parameter: `X-Content-Type-Options`
  
  
  
* URL: [https://localhost:44308/FanClub/Quiz](https://localhost:44308/FanClub/Quiz)
  
  
  * Method: `GET`
  
  
  * Parameter: `X-Content-Type-Options`
  
  
  
* URL: [https://localhost:44308/Home/Stories](https://localhost:44308/Home/Stories)
  
  
  * Method: `GET`
  
  
  * Parameter: `X-Content-Type-Options`
  
  
  
* URL: [https://localhost:44308/Home/Stories](https://localhost:44308/Home/Stories)
  
  
  * Method: `POST`
  
  
  * Parameter: `X-Content-Type-Options`
  
  
  
* URL: [https://localhost:44308/FanClub/Quiz](https://localhost:44308/FanClub/Quiz)
  
  
  * Method: `POST`
  
  
  * Parameter: `X-Content-Type-Options`
  
  
  
* URL: [https://localhost:44308/Home/Privacy](https://localhost:44308/Home/Privacy)
  
  
  * Method: `GET`
  
  
  * Parameter: `X-Content-Type-Options`
  
  
  
* URL: [https://localhost:44308/Account/Login?ReturnUrl=%2FHome%2FStories](https://localhost:44308/Account/Login?ReturnUrl=%2FHome%2FStories)
  
  
  * Method: `GET`
  
  
  * Parameter: `X-Content-Type-Options`
  
  
  
* URL: [https://localhost:44308/lib/bootstrap/dist/js/bootstrap.bundle.min.js](https://localhost:44308/lib/bootstrap/dist/js/bootstrap.bundle.min.js)
  
  
  * Method: `GET`
  
  
  * Parameter: `X-Content-Type-Options`
  
  
  
* URL: [https://localhost:44308/FanClub](https://localhost:44308/FanClub)
  
  
  * Method: `GET`
  
  
  * Parameter: `X-Content-Type-Options`
  
  
  
* URL: [https://localhost:44308/Media/Social](https://localhost:44308/Media/Social)
  
  
  * Method: `GET`
  
  
  * Parameter: `X-Content-Type-Options`
  
  
  
* URL: [https://localhost:44308/](https://localhost:44308/)
  
  
  * Method: `GET`
  
  
  * Parameter: `X-Content-Type-Options`
  
  
  
* URL: [https://localhost:44308/Media/Resources](https://localhost:44308/Media/Resources)
  
  
  * Method: `GET`
  
  
  * Parameter: `X-Content-Type-Options`
  
  
  
* URL: [https://localhost:44308/css/site.css](https://localhost:44308/css/site.css)
  
  
  * Method: `GET`
  
  
  * Parameter: `X-Content-Type-Options`
  
  
  
* URL: [https://localhost:44308/Account/Register](https://localhost:44308/Account/Register)
  
  
  * Method: `GET`
  
  
  * Parameter: `X-Content-Type-Options`
  
  
  
  

Instances: 24

### Solution
<p>Ensure that the application/web server sets the Content-Type header appropriately, and that it sets the X-Content-Type-Options header to 'nosniff' for all web pages.</p><p>If possible, ensure that the end user uses a standards-compliant and modern web browser that does not perform MIME-sniffing at all, or that can be directed by the web application/web server to not perform MIME-sniffing.</p>

### Other information
<p>This issue still applies to error type pages (401, 403, 500, etc.) as those pages are often still affected by injection issues, in which case there is still concern for browsers sniffing pages away from their actual content type.</p><p>At "High" threshold this scan rule will not alert on client or server error responses.</p>

### Reference
* http://msdn.microsoft.com/en-us/library/ie/gg622941%28v=vs.85%29.aspx
* https://owasp.org/www-community/Security_Headers

  
#### CWE Id : 16

#### WASC Id : 15

#### Source ID : 3

  

  

### X-Content-Type-Options Header Missing
##### Low (Medium)

  


#### Description
<p>The Anti-MIME-Sniffing header X-Content-Type-Options was not set to 'nosniff'. This allows older versions of Internet Explorer and Chrome to perform MIME-sniffing on the response body, potentially causing the response body to be interpreted and displayed as a content type other than the declared content type. Current (early 2014) and legacy versions of Firefox will use the declared content type (if one is set), rather than performing MIME-sniffing.</p>

  

* URL: [https://snippets.cdn.mozilla.net/us-west/bundles-pregen/Firefox/en-us/default.json](https://snippets.cdn.mozilla.net/us-west/bundles-pregen/Firefox/en-us/default.json)
  
  
  * Method: `GET`
  
  
  * Parameter: `X-Content-Type-Options`
  
  
  
  

Instances: 1

### Solution
<p>Ensure that the application/web server sets the Content-Type header appropriately, and that it sets the X-Content-Type-Options header to 'nosniff' for all web pages.</p><p>If possible, ensure that the end user uses a standards-compliant and modern web browser that does not perform MIME-sniffing at all, or that can be directed by the web application/web server to not perform MIME-sniffing.</p>

### Other information
<p>This issue still applies to error type pages (401, 403, 500, etc.) as those pages are often still affected by injection issues, in which case there is still concern for browsers sniffing pages away from their actual content type.</p><p>At "High" threshold this scan rule will not alert on client or server error responses.</p>

### Reference
* http://msdn.microsoft.com/en-us/library/ie/gg622941%28v=vs.85%29.aspx
* https://owasp.org/www-community/Security_Headers

  
#### CWE Id : 16

#### WASC Id : 15

#### Source ID : 3

  

  

### X-Content-Type-Options Header Missing
##### Low (Medium)

  


#### Description
<p>The Anti-MIME-Sniffing header X-Content-Type-Options was not set to 'nosniff'. This allows older versions of Internet Explorer and Chrome to perform MIME-sniffing on the response body, potentially causing the response body to be interpreted and displayed as a content type other than the declared content type. Current (early 2014) and legacy versions of Firefox will use the declared content type (if one is set), rather than performing MIME-sniffing.</p>

  

* URL: [https://content-signature-2.cdn.mozilla.net/chains/remote-settings.content-signature.mozilla.org-2021-03-22-17-58-04.chain](https://content-signature-2.cdn.mozilla.net/chains/remote-settings.content-signature.mozilla.org-2021-03-22-17-58-04.chain)
  
  
  * Method: `GET`
  
  
  * Parameter: `X-Content-Type-Options`
  
  
  
* URL: [https://content-signature-2.cdn.mozilla.net/chains/pinning-preload.content-signature.mozilla.org-2021-03-22-17-58-04.chain](https://content-signature-2.cdn.mozilla.net/chains/pinning-preload.content-signature.mozilla.org-2021-03-22-17-58-04.chain)
  
  
  * Method: `GET`
  
  
  * Parameter: `X-Content-Type-Options`
  
  
  
* URL: [https://content-signature-2.cdn.mozilla.net/chains/onecrl.content-signature.mozilla.org-2021-03-22-17-58-02.chain](https://content-signature-2.cdn.mozilla.net/chains/onecrl.content-signature.mozilla.org-2021-03-22-17-58-02.chain)
  
  
  * Method: `GET`
  
  
  * Parameter: `X-Content-Type-Options`
  
  
  
  

Instances: 3

### Solution
<p>Ensure that the application/web server sets the Content-Type header appropriately, and that it sets the X-Content-Type-Options header to 'nosniff' for all web pages.</p><p>If possible, ensure that the end user uses a standards-compliant and modern web browser that does not perform MIME-sniffing at all, or that can be directed by the web application/web server to not perform MIME-sniffing.</p>

### Other information
<p>This issue still applies to error type pages (401, 403, 500, etc.) as those pages are often still affected by injection issues, in which case there is still concern for browsers sniffing pages away from their actual content type.</p><p>At "High" threshold this scan rule will not alert on client or server error responses.</p>

### Reference
* http://msdn.microsoft.com/en-us/library/ie/gg622941%28v=vs.85%29.aspx
* https://owasp.org/www-community/Security_Headers

  
#### CWE Id : 16

#### WASC Id : 15

#### Source ID : 3

  

  

### Charset Mismatch 
##### Informational (Low)

  


#### Description
<p>This check identifies responses where the HTTP Content-Type header declares a charset different from the charset defined by the body of the HTML or XML. When there's a charset mismatch between the HTTP header and content body Web browsers can be forced into an undesirable content-sniffing mode to determine the content's correct character set.</p><p></p><p>An attacker could manipulate content on the page to be interpreted in an encoding of their choice. For example, if an attacker can control content at the beginning of the page, they could inject script using UTF-7 encoded text and manipulate some browsers into interpreting that text.</p>

  

* URL: [https://aus5.mozilla.org/update/3/SystemAddons/85.0.2/20210208133944/WINNT_x86_64-msvc-x64/en-US/release/Windows_NT%2010.0.0.0.19041.746%20(x64)/default/default/update.xml](https://aus5.mozilla.org/update/3/SystemAddons/85.0.2/20210208133944/WINNT_x86_64-msvc-x64/en-US/release/Windows_NT%2010.0.0.0.19041.746%20(x64)/default/default/update.xml)
  
  
  * Method: `GET`
  
  
  
  

Instances: 1

### Solution
<p>Force UTF-8 for all text content in both the HTTP header and meta tags in HTML or encoding declarations in XML.</p>

### Other information
<p>There was a charset mismatch between the HTTP Header and the XML encoding declaration: [utf-8] and [null] do not match.</p>

### Reference
* http://code.google.com/p/browsersec/wiki/Part2#Character_set_handling_and_detection

  
#### CWE Id : 16

#### WASC Id : 15

#### Source ID : 3

  

  

### Information Disclosure - Suspicious Comments
##### Informational (Medium)

  


#### Description
<p>The response appears to contain suspicious comments which may help an attacker. Note: Matches made within script blocks or files are against the entire content not only comments.</p>

  

* URL: [https://localhost:44308/Account/Register](https://localhost:44308/Account/Register)
  
  
  * Method: `GET`
  
  
  * Evidence: `where`
  
  
  
* URL: [https://localhost:44308/Account/Register](https://localhost:44308/Account/Register)
  
  
  * Method: `POST`
  
  
  * Evidence: `where`
  
  
  
  

Instances: 2

### Solution
<p>Remove all comments that return information that may help an attacker and fix any underlying problems they refer to.</p>

### Other information
<p>The following pattern was used: \bWHERE\b and was detected in the element starting with: "<!-- Per GA the validation both work in and outside the form, it just changes where the error shows up -->", see evidence field for the suspicious comment/snippet.</p>

### Reference
* 

  
#### CWE Id : 200

#### WASC Id : 13

#### Source ID : 3

  

  

### Information Disclosure - Suspicious Comments
##### Informational (Low)

  


#### Description
<p>The response appears to contain suspicious comments which may help an attacker. Note: Matches made within script blocks or files are against the entire content not only comments.</p>

  

* URL: [https://localhost:44308/lib/bootstrap/dist/js/bootstrap.bundle.min.js](https://localhost:44308/lib/bootstrap/dist/js/bootstrap.bundle.min.js)
  
  
  * Method: `GET`
  
  
  * Evidence: `from`
  
  
  
* URL: [https://localhost:44308/lib/jquery/dist/jquery.min.js](https://localhost:44308/lib/jquery/dist/jquery.min.js)
  
  
  * Method: `GET`
  
  
  * Evidence: `username`
  
  
  
  

Instances: 2

### Solution
<p>Remove all comments that return information that may help an attacker and fix any underlying problems they refer to.</p>

### Other information
<p>The following pattern was used: \bFROM\b and was detected in the element starting with: "!function(t,e){"object"==typeof exports&&"undefined"!=typeof module?e(exports,require("jquery")):"function"==typeof define&&defi", see evidence field for the suspicious comment/snippet.</p>

### Reference
* 

  
#### CWE Id : 200

#### WASC Id : 13

#### Source ID : 3

  

  

### Loosely Scoped Cookie
##### Informational (Low)

  


#### Description
<p>Cookies can be scoped by domain or path. This check is only concerned with domain scope.The domain scope applied to a cookie determines which domains can access it. For example, a cookie can be scoped strictly to a subdomain e.g. www.nottrusted.com, or loosely scoped to a parent domain e.g. nottrusted.com. In the latter case, any subdomain of nottrusted.com can access the cookie. Loosely scoped cookies are common in mega-applications like google.com and live.com. Cookies set from a subdomain like app.foo.bar are transmitted only to that domain by the browser. However, cookies scoped to a parent-level domain may be transmitted to the parent, or any subdomain of the parent.</p>

  

* URL: [https://localhost:44308/Account/Login](https://localhost:44308/Account/Login)
  
  
  * Method: `GET`
  
  
  
* URL: [https://localhost:44308/Account/Register](https://localhost:44308/Account/Register)
  
  
  * Method: `POST`
  
  
  
* URL: [https://localhost:44308/Account/Register](https://localhost:44308/Account/Register)
  
  
  * Method: `GET`
  
  
  
* URL: [https://localhost:44308/Account/Register](https://localhost:44308/Account/Register)
  
  
  * Method: `GET`
  
  
  
  

Instances: 4

### Solution
<p>Always scope cookies to a FQDN (Fully Qualified Domain Name).</p>

### Other information
<p>The origin domain used for comparison was: </p><p>localhost</p><p>.AspNetCore.Antiforgery.Ya7HB32Ca-Y=CfDJ8LBJaPicz1hFkjueW89XL3TG7QrxfvBzNXXrBCWSNwVCsR7TeDmBVKOUCsDRGl7T1R-69hMB0xjmQcPgFXbPdXVBb7RHrd5fLTJYpi6WMXTXjjj68CgzR_W3c34suDf00YkiOEvNPA0qWdRvbIFbBPA</p><p></p>

### Reference
* https://tools.ietf.org/html/rfc6265#section-4.1
* https://owasp.org/www-project-web-security-testing-guide/v41/4-Web_Application_Security_Testing/06-Session_Management_Testing/02-Testing_for_Cookies_Attributes.html
* http://code.google.com/p/browsersec/wiki/Part2#Same-origin_policy_for_cookies

  
#### CWE Id : 565

#### WASC Id : 15

#### Source ID : 3

  

  

### Timestamp Disclosure - Unix
##### Informational (Low)

  


#### Description
<p>A timestamp was disclosed by the application/web server - Unix</p>

  

* URL: [https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/fxmonitor-breaches/changeset?_expected=1612303475647](https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/fxmonitor-breaches/changeset?_expected=1612303475647)
  
  
  * Method: `GET`
  
  
  * Evidence: `36395491`
  
  
  
* URL: [https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/fxmonitor-breaches/changeset?_expected=1612303475647](https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/fxmonitor-breaches/changeset?_expected=1612303475647)
  
  
  * Method: `GET`
  
  
  * Evidence: `11657763`
  
  
  
* URL: [https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/fxmonitor-breaches/changeset?_expected=1612303475647](https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/fxmonitor-breaches/changeset?_expected=1612303475647)
  
  
  * Method: `GET`
  
  
  * Evidence: `29020808`
  
  
  
* URL: [https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/fxmonitor-breaches/changeset?_expected=1612303475647](https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/fxmonitor-breaches/changeset?_expected=1612303475647)
  
  
  * Method: `GET`
  
  
  * Evidence: `20580060`
  
  
  
* URL: [https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/fxmonitor-breaches/changeset?_expected=1612303475647](https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/fxmonitor-breaches/changeset?_expected=1612303475647)
  
  
  * Method: `GET`
  
  
  * Evidence: `47391665`
  
  
  
* URL: [https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/fxmonitor-breaches/changeset?_expected=1612303475647](https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/fxmonitor-breaches/changeset?_expected=1612303475647)
  
  
  * Method: `GET`
  
  
  * Evidence: `14610585`
  
  
  
* URL: [https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/fxmonitor-breaches/changeset?_expected=1612303475647](https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/fxmonitor-breaches/changeset?_expected=1612303475647)
  
  
  * Method: `GET`
  
  
  * Evidence: `48881308`
  
  
  
* URL: [https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/fxmonitor-breaches/changeset?_expected=1612303475647](https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/fxmonitor-breaches/changeset?_expected=1612303475647)
  
  
  * Method: `GET`
  
  
  * Evidence: `40767652`
  
  
  
* URL: [https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/fxmonitor-breaches/changeset?_expected=1612303475647](https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/fxmonitor-breaches/changeset?_expected=1612303475647)
  
  
  * Method: `GET`
  
  
  * Evidence: `12218087`
  
  
  
* URL: [https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/fxmonitor-breaches/changeset?_expected=1612303475647](https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/fxmonitor-breaches/changeset?_expected=1612303475647)
  
  
  * Method: `GET`
  
  
  * Evidence: `15453048`
  
  
  
* URL: [https://firefox.settings.services.mozilla.com/v1/buckets/security-state/collections/onecrl/changeset?_expected=1612908330359&_since=%221612664984721%22](https://firefox.settings.services.mozilla.com/v1/buckets/security-state/collections/onecrl/changeset?_expected=1612908330359&_since=%221612664984721%22)
  
  
  * Method: `GET`
  
  
  * Evidence: `90944665`
  
  
  
* URL: [https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/fxmonitor-breaches/changeset?_expected=1612303475647](https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/fxmonitor-breaches/changeset?_expected=1612303475647)
  
  
  * Method: `GET`
  
  
  * Evidence: `40960499`
  
  
  
* URL: [https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/fxmonitor-breaches/changeset?_expected=1612303475647](https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/fxmonitor-breaches/changeset?_expected=1612303475647)
  
  
  * Method: `GET`
  
  
  * Evidence: `28510459`
  
  
  
* URL: [https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/fxmonitor-breaches/changeset?_expected=1612303475647](https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/fxmonitor-breaches/changeset?_expected=1612303475647)
  
  
  * Method: `GET`
  
  
  * Evidence: `24853850`
  
  
  
* URL: [https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/fxmonitor-breaches/changeset?_expected=1612303475647](https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/fxmonitor-breaches/changeset?_expected=1612303475647)
  
  
  * Method: `GET`
  
  
  * Evidence: `44320330`
  
  
  
* URL: [https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/fxmonitor-breaches/changeset?_expected=1612303475647](https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/fxmonitor-breaches/changeset?_expected=1612303475647)
  
  
  * Method: `GET`
  
  
  * Evidence: `28364826`
  
  
  
* URL: [https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/fxmonitor-breaches/changeset?_expected=1612303475647](https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/fxmonitor-breaches/changeset?_expected=1612303475647)
  
  
  * Method: `GET`
  
  
  * Evidence: `91890110`
  
  
  
* URL: [https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/fxmonitor-breaches/changeset?_expected=1612303475647](https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/fxmonitor-breaches/changeset?_expected=1612303475647)
  
  
  * Method: `GET`
  
  
  * Evidence: `22437749`
  
  
  
* URL: [https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/fxmonitor-breaches/changeset?_expected=1612303475647](https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/fxmonitor-breaches/changeset?_expected=1612303475647)
  
  
  * Method: `GET`
  
  
  * Evidence: `86591957`
  
  
  
* URL: [https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/fxmonitor-breaches/changeset?_expected=1612303475647](https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/fxmonitor-breaches/changeset?_expected=1612303475647)
  
  
  * Method: `GET`
  
  
  * Evidence: `26183992`
  
  
  
  

Instances: 108

### Solution
<p>Manually confirm that the timestamp data is not sensitive, and that the data cannot be aggregated to disclose exploitable patterns.</p>

### Other information
<p>36395491, which evaluates to: 1971-02-25 21:51:31</p>

### Reference
* http://projects.webappsec.org/w/page/13246936/Information%20Leakage

  
#### CWE Id : 200

#### WASC Id : 13

#### Source ID : 3
