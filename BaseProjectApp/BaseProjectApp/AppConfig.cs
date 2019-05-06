namespace BaseProjectApp
{
    public static class AppConfig
    {
        /*
         * POST https://registro-eb-api.azurewebsites.net/auth/login *
         * GET https://registro-eb-api.azurewebsites.net/asistente/reporte/registrados/operador *
         * GET https://registro-eb-api.azurewebsites.net/asistente/buscar/global/100 **
         * POST https://registro-eb-api.azurewebsites.net/asistente/crear *
         * PUT https://registro-eb-api.azurewebsites.net/asistente/guardar *
         * DELETE https://registro-eb-api.azurewebsites.net/asistente/borrar/100 *
         * GET https://registro-eb-api.azurewebsites.net/asistente/buscar/porusuario/100 ***
         * POST https://registro-eb-api.azurewebsites.net/asistente/manilla/100/true *        
         */
        //-------------  Test  ------------------
        public static string ApiHost = "https://registro-eb-api.azurewebsites.net/";


        public static string AppNameAuth = "auth/";
        public static string AppNameAsistente = "asistente/";


        public static string POST_LOGIN = "login";
        public static string GET_REPORTE = "reporte/registrados/operador";
        public static string GET_BUSCAR_ID = "buscar/global/100";
        public static string POST_ADD_ASISTENTE = "crear";
        public static string PUT_UPDATE_ASISTENTE = "guardar";
        public static string DELETE_ASISTENTE = "borrar/100";
        public static string POST_MANILLA_ENTREGAR = "manilla/100/true";
    }
}
