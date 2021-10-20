using sql.cdc.listener.CDCTables;
using sql.cdc.listener.Helper;
using System;
using TableDependency.SqlClient;
using TableDependency.SqlClient.Base.EventArgs;

namespace sql.cdc.listener
{
    public static class ListenerService
    {
        public static int COUNTER = 1;

        public static void Start(string connectionString)
        {
            SqlTableDependency<MOCK_DATA> listener = new(connectionString);
            listener.OnChanged += OnChanges;
            listener.Start();
            Console.WriteLine($"Escuchando cambios en tabla:  {TableExtension<MOCK_DATA>.GetTableName()}");
            Console.WriteLine("Presioná una tecla para salir");
            Console.ReadLine();
            listener.Stop();
        }

        private static void OnChanges(object sender, RecordChangedEventArgs<MOCK_DATA> evt)
        {
            Console.WriteLine($"{COUNTER++} Operation: {evt.Entity.Operation} : {evt.Entity.First_name} {evt.Entity.Last_name}");
        }
    }
}
