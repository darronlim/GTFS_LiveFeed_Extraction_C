using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Translink_LiveFeed_Service
{
    public class SQL
    {
        public void FetchBatch(string _connstring, ref int batchID, ref string errormsg)
        {
            SqlDataAdapter adapt = null;
            DataSet dsbl = new DataSet();
            string sSql = "";
            sSql = "select isnull(MAX(batchID),0) from Translink_Vehicle";

            adapt = new SqlDataAdapter(sSql, _connstring);
            adapt.Fill(dsbl);

            if (dsbl.Tables[0].Rows.Count > 0)
            {
                batchID = Convert.ToInt16(dsbl.Tables[0].Rows[0][0]) + 1;
            }
            else
            {
                batchID = 1;
            }
        }

        //13.05.2019 Added fetch Trip update fields from translink_tripupdate table
        public void FetchGTFS(string _connstring, ref DataSet dsbl, ref string errormsg)
        {
            SqlDataAdapter adapt = null;
            dsbl = new DataSet();
            string sSql = "";
            sSql = "select * from Translink_Vehicle where 1=0";

            adapt = new SqlDataAdapter(sSql, _connstring);
            adapt.Fill(dsbl, "Vehicle");

            //13.05.2019 Fetch Trip update fields from translink_tripupdate table
            sSql = "select * from Translink_TripUpdate where 1=0";

            adapt = new SqlDataAdapter(sSql, _connstring);
            adapt.Fill(dsbl, "TripUpdate");

        }

        public void FetchAll(string _connstring, ref DataSet dsbl, ref string errormsg)
        {
            SqlDataAdapter adapt = null;
            dsbl = new DataSet();
            string sSql = "";
            sSql = "select * from Translink_Vehicle";

            adapt = new SqlDataAdapter(sSql, _connstring);
            adapt.Fill(dsbl);
        }

        public void InsertGTFS(string _connstring, DataSet dsbl, ref string errormsg)
        {
            SqlCommand cmd;
            SqlConnection dbconn = null;
            string sSql = "";
            DataRow dsrow = null;
            int batchID = 0;

            sSql = "insert into Translink_Vehicle (BatchID, CreatedDate, VehicleID, LicensePlate, VehicleLabel, CongestionLevel, CurrentStatus, CurrentStopStatus, CurrentStopSequence, " +
                "OccupancyStatus, StopID, VehicleTimestamp, VehicleDirectionID, VehicleRouteID, VehicleScheduleRelationship, VehicleStartDate, " +
                "VehicleStartTime, VehicleTripID, VehicleBearing, VehicleLatitude, VehicleLongitude, ID) VALUES (@BatchID, GETDATE(), @VehicleID, @LicensePlate, @VehicleLabel," +
                " @CongestionLevel, @CurrentStatus, @CurrentStopStatus, @CurrentStopSequence, @OccupancyStatus, @StopID, @VehicleTimestamp, @VehicleDirectionID, @VehicleRouteID, " +
                "@VehicleScheduleRelationship, @VehicleStartDate, @VehicleStartTime, @VehicleTripID, @VehicleBearing, @VehicleLatitude, @VehicleLongitude, @ID)";

            // ScheduleRelationship, StartTime, TripTimestamp, ID, AlertPeriod, AlertCause, " +
            //"AlertDescription, AlertEffect, AlertHeaderText, AlertInformedEntity, AlertURL, VehicleID, LicensePlate, VehicleLabel, CurrentStatus, CurrentStopStatus, CurrentStopSequence, " +
            //"OccupancyStatus, StopID, VehicleTimestamp, VehicleDirectionID, VehicleRouteID, VehicleScheduleRelationship, VehicleStartDate, VehicleStartTime, VehicleTripID, VehicleBearing, " +
            //"VehicleLongitude, VehicleLatitude 
            //@ScheduleRelationship, @StartTime, @TripTimestamp, @ID, @AlertPeriod, " +
            //    "@AlertCause, @AlertDescription, @AlertEffect, @AlertHeaderText, @AlertInformedEntity, @AlertURL, @VehicleID, @LicensePlate, @VehicleLabel, @CurrentStatus, @CurrentStopStatus, " +
            //    "@CurrentStopSequence, @OccupancyStatus, @StopID, @VehicleTimestamp, @VehicleDirectionID, @VehicleRouteID, @VehicleScheduleRelationship, @VehicleStartDate, @VehicleStartTime, " +
            //    "@VehicleTripID, @VehicleBearing, @VehicleLongitude, @VehicleLatitude

            dbconn = new SqlConnection(_connstring);
            dbconn.Open();

            FetchBatch(_connstring, ref batchID, ref errormsg);

            for (int i = 0; i < dsbl.Tables[0].Rows.Count; i++)
            {
                dsrow = dsbl.Tables[0].Rows[i];

                cmd = new SqlCommand(sSql, dbconn);

                cmd.Parameters.Add(new SqlParameter("@BatchID", SqlDbType.Int));
                cmd.Parameters.Add(new SqlParameter("@VehicleID", SqlDbType.VarChar, 100));
                cmd.Parameters.Add(new SqlParameter("@VehicleLabel", SqlDbType.VarChar, 100));
                cmd.Parameters.Add(new SqlParameter("@CongestionLevel", SqlDbType.NChar, 10));
                cmd.Parameters.Add(new SqlParameter("@CurrentStatus", SqlDbType.VarChar, 100));
                cmd.Parameters.Add(new SqlParameter("@CurrentStopStatus", SqlDbType.VarChar, 100));
                cmd.Parameters.Add(new SqlParameter("@CurrentStopSequence", SqlDbType.VarChar, 100));
                cmd.Parameters.Add(new SqlParameter("@OccupancyStatus", SqlDbType.VarChar, 100));
                cmd.Parameters.Add(new SqlParameter("@StopID", SqlDbType.VarChar, 100));
                cmd.Parameters.Add(new SqlParameter("@VehicleTimestamp", SqlDbType.VarChar, 100));
                cmd.Parameters.Add(new SqlParameter("@VehicleDirectionID", SqlDbType.VarChar, 100));
                cmd.Parameters.Add(new SqlParameter("@VehicleRouteID", SqlDbType.VarChar, 100));
                cmd.Parameters.Add(new SqlParameter("@VehicleScheduleRelationship", SqlDbType.VarChar, 100));
                cmd.Parameters.Add(new SqlParameter("@VehicleStartDate", SqlDbType.VarChar, 100));
                cmd.Parameters.Add(new SqlParameter("@VehicleStartTime", SqlDbType.VarChar, 100));
                cmd.Parameters.Add(new SqlParameter("@VehicleTripID", SqlDbType.VarChar, 100));
                cmd.Parameters.Add(new SqlParameter("@LicensePlate", SqlDbType.VarChar, 10));
                cmd.Parameters.Add(new SqlParameter("@VehicleBearing", SqlDbType.VarChar, 50));
                cmd.Parameters.Add(new SqlParameter("@VehicleLongitude", SqlDbType.NChar, 10));
                cmd.Parameters.Add(new SqlParameter("@VehicleLatitude", SqlDbType.NChar, 10));
                cmd.Parameters.Add(new SqlParameter("@VehicleOdometer", SqlDbType.NChar, 10));
                cmd.Parameters.Add(new SqlParameter("@VehicleSpeed", SqlDbType.NChar, 10));
                //12.05.2019 Added ID (Entity.id)
                cmd.Parameters.Add(new SqlParameter("@ID", SqlDbType.VarChar, 100));

                cmd.Parameters["@BatchID"].Value = batchID;
                cmd.Parameters["@VehicleID"].Value = dsrow["VehicleID"];
                cmd.Parameters["@VehicleLabel"].Value = dsrow["VehicleLabel"];
                cmd.Parameters["@LicensePlate"].Value = dsrow["LicensePlate"];
                cmd.Parameters["@CongestionLevel"].Value = dsrow["CongestionLevel"];
                cmd.Parameters["@CurrentStatus"].Value = dsrow["CurrentStatus"];
                cmd.Parameters["@CurrentStopStatus"].Value = dsrow["CurrentStopStatus"];
                cmd.Parameters["@CurrentStopSequence"].Value = dsrow["CurrentStopSequence"];
                cmd.Parameters["@OccupancyStatus"].Value = dsrow["OccupancyStatus"];
                cmd.Parameters["@StopID"].Value = dsrow["StopID"];
                cmd.Parameters["@VehicleTimestamp"].Value = dsrow["VehicleTimestamp"];
                cmd.Parameters["@VehicleDirectionID"].Value = dsrow["VehicleDirectionID"];
                cmd.Parameters["@VehicleRouteID"].Value = dsrow["VehicleRouteID"];
                cmd.Parameters["@VehicleScheduleRelationship"].Value = dsrow["VehicleScheduleRelationship"];
                cmd.Parameters["@VehicleStartDate"].Value = dsrow["VehicleStartDate"];
                cmd.Parameters["@VehicleStartTime"].Value = dsrow["VehicleStartTime"];
                cmd.Parameters["@VehicleTripID"].Value = dsrow["VehicleTripID"];
                cmd.Parameters["@VehicleBearing"].Value = dsrow["VehicleBearing"];
                cmd.Parameters["@VehicleLongitude"].Value = dsrow["VehicleLongitude"];
                cmd.Parameters["@VehicleLatitude"].Value = dsrow["VehicleLatitude"];
                cmd.Parameters["@VehicleOdometer"].Value = dsrow["VehicleOdometer"];
                cmd.Parameters["@VehicleSpeed"].Value = dsrow["VehicleSpeed"];

                //12.05.2019 Added ID (Entity.id)
                cmd.Parameters["@ID"].Value = dsrow["ID"];

                cmd.ExecuteNonQuery();
            }


            InsertGTFSTripUpdate(_connstring, dsbl, ref errormsg, batchID);
        }

        //12.05.2019 Added insert Trip update function
        //12.05.2019 Added ID to translink_tripupdate table to store Entity.ID
        public void InsertGTFSTripUpdate(string _connstring, DataSet dsbl, ref string errormsg, int BatchID)
        {
            SqlCommand cmd;
            SqlConnection dbconn = null;
            string sSql = "";
            DataRow dsrow = null;


            sSql = "insert into translink_tripupdate (BatchID, CreatedDate, TripID, DirectionID, RouteID, ScheduleRelationship, StartDate, StartTime, " +
             "StopTimeUpdate, Delay, Timestamp, ID) VALUES (@BatchID, GETDATE(), @TripID, @DirectionID, @RouteID, @ScheduleRelationship, @StartDate, @StartTime, @StopTimeUpdate," +
             " @Delay, @Timestamp, @ID)";


            dbconn = new SqlConnection(_connstring);
            dbconn.Open();

            for (int i = 0; i < dsbl.Tables["TripUpdate"].Rows.Count; i++)
            {
                dsrow = dsbl.Tables["TripUpdate"].Rows[i];

                cmd = new SqlCommand(sSql, dbconn);

                cmd.Parameters.Add(new SqlParameter("@BatchID", SqlDbType.Int));
                cmd.Parameters.Add(new SqlParameter("@TripID", SqlDbType.VarChar, 100));
                cmd.Parameters.Add(new SqlParameter("@DirectionID", SqlDbType.Int));
                cmd.Parameters.Add(new SqlParameter("@RouteID", SqlDbType.VarChar, 100));
                cmd.Parameters.Add(new SqlParameter("@ScheduleRelationship", SqlDbType.VarChar, 100));
                cmd.Parameters.Add(new SqlParameter("@StartDate", SqlDbType.VarChar, 100));
                cmd.Parameters.Add(new SqlParameter("@StartTime", SqlDbType.VarChar, 100));
                cmd.Parameters.Add(new SqlParameter("@StopTimeUpdate", SqlDbType.VarChar, 50));
                cmd.Parameters.Add(new SqlParameter("@Delay", SqlDbType.Int));
                cmd.Parameters.Add(new SqlParameter("@Timestamp", SqlDbType.VarChar, 50));

                //12.05.2019 Added ID (Entity.id)
                cmd.Parameters.Add(new SqlParameter("@ID", SqlDbType.VarChar, 100));


                cmd.Parameters["@BatchID"].Value = BatchID;
                cmd.Parameters["@TripID"].Value = dsrow["TripID"];
                cmd.Parameters["@DirectionID"].Value = dsrow["DirectionID"];
                cmd.Parameters["@RouteID"].Value = dsrow["RouteID"];
                cmd.Parameters["@ScheduleRelationship"].Value = dsrow["ScheduleRelationship"];
                cmd.Parameters["@StartDate"].Value = dsrow["StartDate"];
                cmd.Parameters["@StartTime"].Value = dsrow["StartTime"];
                cmd.Parameters["@StopTimeUpdate"].Value = dsrow["StopTimeUpdate"];
                cmd.Parameters["@Delay"].Value = dsrow["Delay"];
                cmd.Parameters["@Timestamp"].Value = dsrow["Timestamp"];

                //12.05.2019 Added ID (Entity.id)
                cmd.Parameters["@ID"].Value = dsrow["ID"];


                cmd.ExecuteNonQuery();
            }
        }
    }
}
