// This file can be replaced during build by using the `fileReplacements` array.
// `ng build` replaces `environment.ts` with `environment.prod.ts`.
// The list of file replacements can be f+ound in `angular.json`.

export const environment = {
  production: false,
  siteBaseUrl: "",
  apiBaseUrl: "https://localhost:44390/api/",
  ssoUrl: "https://acs-sso-accelerator.azurewebsites.net/account/login/1062?returnUrl=http://localhost:4200/sso-callback",
  ClaimEndpoint: "https://acs-sso-accelerator.azurewebsites.net/client-identifier/get-token-claims/1062",
  TokenValidation: "https://acs-sso-accelerator.azurewebsites.net/client-identifier/is-token-valid/1062",
  LogoutEndPoint: "https://acs-sso-accelerator.azurewebsites.net/account/logout/1062?returnUrl=http://localhost:4200/",
  createclient: "https://acs-sso-accelerator-web.azurewebsites.net/",
  CallbackEndpoint: "https://acs-sso-accelerator.azurewebsites.net/account/external-login-callback/1062",
};

/*
 * For easier debugging in development mode, you can import the following file
 * to ignore zone related error stack frames such as `zone.run`, `zoneDelegate.invokeTask`.
 *
 * This import should be commented out in production mode because it will have a negative impact
 * on performance if an error is thrown.
 */
// import 'zone.js/plugins/zone-error';  // Included with Angular CLI.
