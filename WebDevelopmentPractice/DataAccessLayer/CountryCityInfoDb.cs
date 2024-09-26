using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

using WebDevelopmentPractice.DBConnection;
using WebDevelopmentPractice.Models;


namespace WebDevelopmentPractice.DataAccessLayer
{
    public class CountryCityInfoDb
    {
        OracleConnection con = null;
        DbConnection dbConnection = null;

        public List<CountryModel> GetCountry()
        {
            List<CountryModel> objCountryModelList = new List<CountryModel>();
            
            try
            {
                dbConnection = new DbConnection();
                con = new OracleConnection(dbConnection.getConnectionString());
                using (OracleCommand command = new OracleCommand())
                {
                    DataSet ds = new DataSet();
                    command.CommandText = "SP_GET_ALL_COUNTRY";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Connection = con;
                    command.BindByName = true;

                    command.Parameters.Add("o_country_cursor", OracleDbType.RefCursor, ParameterDirection.Output);

                    OracleDataAdapter da = new OracleDataAdapter();
                    da.SelectCommand = command;
                    da.Fill(ds);
                    int count = ds.Tables[0].Rows.Count;
                    if (count > 0)
                    {
                        objCountryModelList = (from DataRow dr in ds.Tables[0].Rows
                                                   select new CountryModel()
                                                   {
                                                       countryId = dr["COUNTRYID"].ToString(),
                                                       countryName = dr["COUNTRYNAME"].ToString()
                                                   }).ToList();

                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (con != null && con.State == System.Data.ConnectionState.Open)
                    con.Close();
                con.Dispose();
            }

            return objCountryModelList;
        }


        public List<CityModel> GetCitiesByCountryId(string countryId)
        {
            List<CityModel> objCityModelList = new List<CityModel>();
           
            try
            {
                dbConnection = new DbConnection();
                con = new OracleConnection(dbConnection.getConnectionString());
                using (OracleCommand command = new OracleCommand())
                {
                    DataSet ds = new DataSet();
                    command.CommandText = "SP_GET_ALL_CITY";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Connection = con;
                    command.BindByName = true;


                    command.Parameters.Add(new OracleParameter("p_country_id", countryId));
                    command.Parameters.Add("o_city_cursor", OracleDbType.RefCursor, ParameterDirection.Output);

                    OracleDataAdapter da = new OracleDataAdapter();
                    da.SelectCommand = command;
                    da.Fill(ds);
                    int count = ds.Tables[0].Rows.Count;
                    if (count > 0)
                    {
                        objCityModelList = (from DataRow dr in ds.Tables[0].Rows
                                            select new CityModel()
                                            {
                                                cityId = dr["CITYID"].ToString(),
                                                cityName = dr["CITYNAME"].ToString()
                                            }).ToList();

                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (con != null && con.State == System.Data.ConnectionState.Open)
                    con.Close();
                con.Dispose();
            }

            return objCityModelList;
        }



        public List<CityModel> GetPostcodesByCityId(string cityId)
        {
            List<CityModel> objPostcodeModelList = new List<CityModel>();

            try
            {
                dbConnection = new DbConnection();
                con = new OracleConnection(dbConnection.getConnectionString());
                using (OracleCommand command = new OracleCommand())
                {
                    DataSet ds = new DataSet();
                    command.CommandText = "SP_GET_ALL_POSTCODE";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Connection = con;
                    command.BindByName = true;


                    command.Parameters.Add(new OracleParameter("p_city_id", cityId));
                    command.Parameters.Add("o_postcode_cursor", OracleDbType.RefCursor, ParameterDirection.Output);

                    OracleDataAdapter da = new OracleDataAdapter();
                    da.SelectCommand = command;
                    da.Fill(ds);
                    int count = ds.Tables[0].Rows.Count;
                    if (count > 0)
                    {
                        objPostcodeModelList = (from DataRow dr in ds.Tables[0].Rows
                                            select new CityModel()
                                            {
                                                postcode_Id = dr["POSTCODE_ID"].ToString(),
                                                postcode = dr["POSTCODE"].ToString()
                                            }).ToList();

                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (con != null && con.State == System.Data.ConnectionState.Open)
                    con.Close();
                con.Dispose();
            }

            return objPostcodeModelList;
        }


        public List<CityModel> GetAreasByPostcodeId(string postcode_Id)
        
        {
            List<CityModel> objAreaModelList = new List<CityModel>();

            try
            {
                dbConnection = new DbConnection();
                con = new OracleConnection(dbConnection.getConnectionString());
                using (OracleCommand command = new OracleCommand())
                {
                    DataSet ds = new DataSet();
                    command.CommandText = "SP_GET_ALL_AREA";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Connection = con;
                    command.BindByName = true;


                    command.Parameters.Add(new OracleParameter("p_postcode_id", postcode_Id));
                    command.Parameters.Add("o_area_cursor", OracleDbType.RefCursor, ParameterDirection.Output);

                    OracleDataAdapter da = new OracleDataAdapter();
                    da.SelectCommand = command;
                    da.Fill(ds);
                    int count = ds.Tables[0].Rows.Count;
                    if (count > 0)
                    {
                        objAreaModelList = (from DataRow dr in ds.Tables[0].Rows
                                                select new CityModel()
                                                {
                                                    areaId = dr["AREAID"].ToString(),
                                                    area = dr["AREA"].ToString()
                                                }).ToList();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (con != null && con.State == System.Data.ConnectionState.Open)
                    con.Close();
                con.Dispose();
            }

            return objAreaModelList;
        }

    }
}
