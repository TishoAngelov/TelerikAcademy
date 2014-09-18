namespace Cars.QueriesExecutor
{
    using System;
    using System.Configuration;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Xml.Linq;

    using Cars.Data;

    public static class Executor
    {
        private static SqlConnection databaseConnection;
        private static CarsDbContext db;

        public static void ExecuteAllFromFile(string queriesFilePath, string resultFilePath)
        {
            db = new CarsDbContext();

            ConnectToDB();

            var xmlQueries = XDocument.Load(queriesFilePath).Element("Queries");
            int valuesCounter = 1;

            foreach (var xmlQuery in xmlQueries.Elements("Query"))
            {
                SqlCommand cmdQuery = new SqlCommand(
                        "SELECT * FROM Cars", databaseConnection);

                var query = "SELECT * FROM Cars ";

                string currentFileName = xmlQuery.Attribute("OutputFileName").Value;
                var orderByCondition = xmlQuery.Element("OrderBy").Value;
                var xmlWhereClauses = xmlQuery.Element("WhereClauses").Elements("WhereClause");

                int counter = 0;

                foreach (var xmlWhereClause in xmlWhereClauses)
                {
                    counter++;
                    valuesCounter++;

                    var propertyName = xmlWhereClause.Attribute("PropertyName").Value;
                    var type = xmlWhereClause.Attribute("Type").Value;
                    var whereClauseValue = xmlWhereClause.Value;

                    if (counter == 1)
                    {
                        cmdQuery.CommandText += " Where ";
                        query += " WHERE ";
                    }
                    else
                    {
                        cmdQuery.CommandText += " And ";
                        query += " AND ";
                    }

                    cmdQuery.CommandText += string.Format("{0} {1} @currValue{2}", propertyName, type, valuesCounter);
                    cmdQuery.Parameters.AddWithValue(string.Format("@currValue{0}", valuesCounter), whereClauseValue);

                    query += propertyName + " " + type + " '" + whereClauseValue + "'";
                }

                cmdQuery.CommandText += " ORDER BY " + orderByCondition;
                query += " ORDER BY " + orderByCondition;

                ////StreamWriter sw = new StreamWriter(resultFilePath + currentFileName);
                ////using (sw)
                ////{
                ////    sw.WriteLine(query);
                ////}

                Console.WriteLine(query);

                ////SqlDataReader reader = cmdQuery.ExecuteReader();
                ////using (reader)
                ////{
                ////    if (reader.Read())
                ////    {
                ////        var model = (string)reader["Model"];
                ////        var transmissionType = (TransmissionType)reader["TransmissionType"];
                ////        var year = (int)reader["Year"];
                ////        var price = (decimal)reader["Price"];
                ////        var manufacturerId = (int)reader["ManufacturerId"];
                ////        var dealerId = (int)reader["DealerId"];
                ////        //if (endDateObj != DBNull.Value)
                ////        //{
                ////        //    endDate = (DateTime)endDateObj;
                ////        //}

                ////        Car currentCar = new Car
                ////        {
                ////            Model = model,
                ////            TransmissionType = transmissionType,
                ////            Year = year,
                ////            Price = price,
                ////            Manufacturer = db.Manufacturers.FirstOrDefault(m => m.Id == manufacturerId),
                ////            Dealer = db.Dealers.FirstOrDefault(d => d.Id == dealerId)
                ////        };
                ////    }
                //// }
            }

            DisconnectFromDB();
        }

        private static void SaveResultInFile(string resultFilePath)
        {
        }

        private static void ConnectToDB()
        {
            ConnectionStringSettings databaseConnectionString = ConfigurationManager.ConnectionStrings["CarsConnectionString"];
            databaseConnection = new SqlConnection(databaseConnectionString.ConnectionString);
            databaseConnection.Open();
        }

        private static void DisconnectFromDB()
        {
            if (databaseConnection != null)
            {
                databaseConnection.Close();
            }
        }
    }
}
