namespace PruebaTécnicaMVCASPADO.Data
{
    public static class SpNames
    {
        // --------------------------------------------------------------
        // Stored Procedures para catalogo de productos
        //----------------------------------------------------------------

        public const string _CrearProducto = "SP_CrearProducto";
        public const string _EditarProducto = "SP_EditarProducto";
        public const string _EliminarProducto = "SP_EliminarProducto";
        public const string _ListarProductos = "SP_ListarProductos";

        // --------------------------------------------------------------
        // Stored Procedures para catalogo de productos
        //----------------------------------------------------------------
        public const string _CrearTipoCliente = "SP_CrearTipoCliente";
        public const string _EditarTipoCliente = "SP_EditarTipoCliente";
        public const string _EliminarTipoCliente = "SP_EliminarTipoCliente";
        public const string _ListarTiposClientes = "SP_ListarTiposClientes";

        // --------------------------------------------------------------
        // Stored Procedures para catalogo de Clientes
        //----------------------------------------------------------------

        internal static string _CrearCliente="SP_CrearCliente";
        internal static string _EditarCliente="SP_EditarCLiente";
        internal static string _EliminarCliente="SP_EliminarCliente";
        internal static string _ListarCliente="SP_ListarCLiente";
                
        // --------------------------------------------------------------
        // Stored Procedures para Facturacion
        //-------------------------------------------------------

        internal static string _CrearFactura="SP_GenerarFactura";
        internal static string _ListarFacturas="SP_GenerarFactura";
        internal static string _BuscarFactura="SP_EliminarCliente";



    }
}

