
namespace Com.Sapient.Contracts.V1 {
    public static class ApiRoutes {
        private const string Root = "api";
        private const string Version = "v1";
        private const string Base = Root + "/" + Version;

        public static class Users {
            public const string Authenticate = Base + "/login";
            public const string ConfirmEmail = Base + "/ConfirmEmail";
            public const string Get = Base + "/login";
            public const string GetFavouriteQuestions = Base + "/securityQuestions";
            public const string GetResetPassword = Base + "/securityAnswers/{userId}";
            public const string Delete = Base + "/delete";
            public const string VerifyOtpPage = Base + "/verifyOtp";

            public const string GetAll = Base + "/login/getall";
            public const string Logout = Base + "/logout";
            public const string Deactivate = Base + "/deactivate";
            public const string GetOtpPage = Base + "/otp";
            public const string SendPasswordResetLink = Base + "/password-reset";
            public const string VerifyPasswordResetLink = Base + "/verify";
           

        }
    }
}
