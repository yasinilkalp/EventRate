namespace EventRate.Core.Base.Responses
{
    /// <summary>
    /// It provides global result message keys.
    /// </summary>
    public abstract class ResultMessages
    {
        public static string Success => "messages.success.general.ok";
        public static string InvalidModel => "messages.error.general.invalidModel";
        public static string UnhandledException => "messages.error.general.unhandledException";
        public static string UnAuthorized => "messages.error.general.unAuthorized";
        public static string NotValidateToken => "messages.error.general.notValidateToken";
        public static string InternalServerError => "messages.error.general.internalServerError";
        public static string NotFound => "messages.error.general.notFound";
        public static string NotCreated => "messages.error.general.notCreated";
        public static string NotUnique => "messages.error.general.notUnique";
        public static string NotUpdated => "messages.error.general.notUpdated";
        public static string NotRemoved => "messages.error.general.notRemoved";
        public static string NotSended => "messages.error.general.notSended";
        public static string SuccessCreated => "messages.success.general.created";
        public static string SuccessUpdated => "messages.success.general.updated";
        public static string SuccessRemoved => "messages.success.general.removed";
        public static string Expired => "messages.error.customer.expired";

    }
}
