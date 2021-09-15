using DvdLibraryWebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Data;

namespace DvdLibraryWebApi.Models
{
    public class DvdRepositoryADO : IDvdRepository
    {
        readonly string connectionString = ConfigurationManager.ConnectionStrings["DvdApp"].ConnectionString;

        public Dvd Create(Dvd dvd)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = connectionString;
                SqlCommand cmd = new SqlCommand
                {
                    Connection = conn,
                    CommandType = CommandType.StoredProcedure,

                    CommandText = "DvdCreate"
                };

                SqlParameter outputIdParam = new SqlParameter("@DvdId", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                };
                cmd.Parameters.Add(outputIdParam);
                cmd.Parameters.AddWithValue("@Title", dvd.Title);
                cmd.Parameters.AddWithValue("@ReleaseYear", dvd.ReleaseYear);
                cmd.Parameters.AddWithValue("@Director", dvd.Director);
                if (dvd.Rating == null)
                {
                    dvd.Rating = "";
                }
                cmd.Parameters.AddWithValue("@Rating", dvd.Rating);
                cmd.Parameters.AddWithValue("@Notes", dvd.Notes);

                conn.Open();
                cmd.ExecuteNonQuery();

                dvd.Id = (int)cmd.Parameters["@DvdId"].Value;
                
            }
            return dvd;
        }

        public void Delete(int id)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = connectionString;
                SqlCommand cmd = new SqlCommand
                {
                    Connection = conn,
                    CommandType = CommandType.StoredProcedure,

                    CommandText = "DvdDelete"
                };

                cmd.Parameters.AddWithValue("@DvdId", id);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public List<Dvd> GetAll()
        {
            List<Dvd> dvds = new List<Dvd>();

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = connectionString;
                SqlCommand cmd = new SqlCommand
                {
                    Connection = conn,
                    CommandType = CommandType.StoredProcedure,

                    CommandText = "DvdSelectAll"
                };

                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Dvd dvd = new Dvd
                        {
                            Id = (int)dr["DvdId"],
                            Title = dr["Title"].ToString(),
                            ReleaseYear = dr["ReleaseYear"].ToString(),
                            Director = dr["Director"].ToString(),
                            Rating = dr["Rating"].ToString(),
                            Notes = dr["Notes"].ToString()
                        };

                        dvds.Add(dvd);
                    }
                }
            }

            return dvds;
        }

        public List<Dvd> GetByDirector(string name)
        {
            List<Dvd> dvds = new List<Dvd>();

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = connectionString;
                SqlCommand cmd = new SqlCommand
                {
                    Connection = conn,
                    CommandType = CommandType.StoredProcedure,
                    
                    CommandText = "DvdSelectByDirector"
                };

                cmd.Parameters.AddWithValue("@Director", name);

                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Dvd dvd = new Dvd
                        {
                            Id = (int)dr["DvdId"],
                            Title = dr["Title"].ToString(),
                            ReleaseYear = dr["ReleaseYear"].ToString(),
                            Director = dr["Director"].ToString(),
                            Rating = dr["Rating"].ToString(),
                            Notes = dr["Notes"].ToString()
                        };

                        dvds.Add(dvd);
                    }
                }
            }

            return dvds;
        }

        public Dvd GetById(int id)
        {
            Dvd dvd = new Dvd();

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = connectionString;
                SqlCommand cmd = new SqlCommand
                {
                    Connection = conn,
                    CommandType = CommandType.StoredProcedure,

                    CommandText = "DvdSelectById"
                };

                cmd.Parameters.AddWithValue("@DvdId", id);

                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        dvd = new Dvd
                        {
                            Id = (int)dr["DvdId"],
                            Title = dr["Title"].ToString(),
                            ReleaseYear = dr["ReleaseYear"].ToString(),
                            Director = dr["Director"].ToString(),
                            Rating = dr["Rating"].ToString(),
                            Notes = dr["Notes"].ToString()
                        };
                    }
                    else
                    {

                        dvd = null;
                    }
                }
            }

            return dvd;
        }

        public List<Dvd> GetByRating(string rating)
        {
            List<Dvd> dvds = new List<Dvd>();

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = connectionString;
                SqlCommand cmd = new SqlCommand
                {
                    Connection = conn,
                    CommandType = CommandType.StoredProcedure,

                    CommandText = "DvdSelectByRating"
                };

                cmd.Parameters.AddWithValue("@Rating", rating);

                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Dvd dvd = new Dvd
                        {
                            Id = (int)dr["DvdId"],
                            Title = dr["Title"].ToString(),
                            ReleaseYear = dr["ReleaseYear"].ToString(),
                            Director = dr["Director"].ToString(),
                            Rating = dr["Rating"].ToString(),
                            Notes = dr["Notes"].ToString()
                        };

                        dvds.Add(dvd);
                    }
                }
            }

            return dvds;
        }

        public List<Dvd> GetByReleaseYear(string year)
        {
            List<Dvd> dvds = new List<Dvd>();

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = connectionString;
                SqlCommand cmd = new SqlCommand
                {
                    Connection = conn,
                    CommandType = CommandType.StoredProcedure,

                    CommandText = "DvdSelectByReleaseYear"
                };

                cmd.Parameters.AddWithValue("@DvdReleaseYear", year);

                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Dvd dvd = new Dvd
                        {
                            Id = (int)dr["DvdId"],
                            Title = dr["Title"].ToString(),
                            ReleaseYear = dr["ReleaseYear"].ToString(),
                            Director = dr["Director"].ToString(),
                            Rating = dr["Rating"].ToString(),
                            Notes = dr["Notes"].ToString()
                        };

                        dvds.Add(dvd);
                    }
                }
            }

            return dvds;
        }

        public List<Dvd> GetByTitle(string title)
        {
            List<Dvd> dvds = new List<Dvd>();

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = connectionString;
                SqlCommand cmd = new SqlCommand
                {
                    Connection = conn,
                    CommandType = CommandType.StoredProcedure,

                    CommandText = "DvdSelectByTitle"
                };

                cmd.Parameters.AddWithValue("@DvdTitle", title);

                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Dvd dvd = new Dvd
                        {
                            Id = (int)dr["DvdId"],
                            Title = dr["Title"].ToString(),
                            ReleaseYear = dr["ReleaseYear"].ToString(),
                            Director = dr["Director"].ToString(),
                            Rating = dr["Rating"].ToString(),
                            Notes = dr["Notes"].ToString()
                        };

                        dvds.Add(dvd);
                    }
                }
            }

            return dvds;
        }

        public void Update(Dvd dvd)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = connectionString;
                SqlCommand cmd = new SqlCommand
                {
                    Connection = conn,
                    CommandType = CommandType.StoredProcedure,

                    CommandText = "DvdUpdate"
                };

                cmd.Parameters.AddWithValue("@DvdId", dvd.Id);
                cmd.Parameters.AddWithValue("@Title", dvd.Title);
                cmd.Parameters.AddWithValue("@ReleaseYear", dvd.ReleaseYear);
                cmd.Parameters.AddWithValue("@Director", dvd.Director);
                cmd.Parameters.AddWithValue("@Rating", dvd.Rating);
                cmd.Parameters.AddWithValue("@Notes", dvd.Notes);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}