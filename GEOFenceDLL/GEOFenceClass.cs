/* Title:           GEO Fence Class
 * Date:            2-14-2020
 * Author:          Terry Holmes
 * 
 * Description:     This is used for any GEO Fence Updates */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewEventLogDLL;

namespace GEOFenceDLL
{
    public class GEOFenceClass
    {
        //setting up the classes
        EventLogClass TheEventLogClass = new EventLogClass();

        GEOFenceImportDataSet aGEOFenceImportDataSet;
        GEOFenceImportDataSetTableAdapters.geofenceimportTableAdapter aGEOFenceImportTableAdapter;

        InsertGEOFenceImportTansactionTableAdapters.QueriesTableAdapter aInsertGEOFenceImportTableAdapter;

        FindGEOFenceTransactionByExactDateDataSet aFindGEOFenceTransactionByExactDateDataSet;
        FindGEOFenceTransactionByExactDateDataSetTableAdapters.FindGEOFenceTransactionByExactDateTableAdapter aFindGEOFenceTransactionByExactDateTableAdapter;

        FindGEOFenceTransactionDateRangeDataSet aFindGEOFenceTransactionDateRangeDataSet;
        FindGEOFenceTransactionDateRangeDataSetTableAdapters.FindGEOFenceTransasctionDateRangeTableAdapter aFindGEOFenceTransactionDateRangeTableAdapter;

        FindGEOFenceByEmployeeIDDataSet aFindGEOFenceByEmployeeIDDataSet;
        FindGEOFenceByEmployeeIDDataSetTableAdapters.FindGEOFenceByEmployeeIDTableAdapter aFindGEOFenceEmployeeIDTableAdapter;

        public FindGEOFenceByEmployeeIDDataSet FindGEOFenceByEmployeeID(int intEmployeeID, DateTime datStartDate, DateTime datEndDate)
        {
            try
            {
                aFindGEOFenceByEmployeeIDDataSet = new FindGEOFenceByEmployeeIDDataSet();
                aFindGEOFenceEmployeeIDTableAdapter = new FindGEOFenceByEmployeeIDDataSetTableAdapters.FindGEOFenceByEmployeeIDTableAdapter();
                aFindGEOFenceEmployeeIDTableAdapter.Fill(aFindGEOFenceByEmployeeIDDataSet.FindGEOFenceByEmployeeID, intEmployeeID, datStartDate, datEndDate);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "GEO Fence Class // Find GEO Fence By Employee ID " + Ex.Message);
            }

            return aFindGEOFenceByEmployeeIDDataSet;
        }
        public FindGEOFenceTransactionDateRangeDataSet FindGEOFenceTransactionDAteRanage(DateTime datStartDate, DateTime datEndDate)
        {
            try
            {
                aFindGEOFenceTransactionDateRangeDataSet = new FindGEOFenceTransactionDateRangeDataSet();
                aFindGEOFenceTransactionDateRangeTableAdapter = new FindGEOFenceTransactionDateRangeDataSetTableAdapters.FindGEOFenceTransasctionDateRangeTableAdapter();
                aFindGEOFenceTransactionDateRangeTableAdapter.Fill(aFindGEOFenceTransactionDateRangeDataSet.FindGEOFenceTransasctionDateRange, datStartDate, datEndDate);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "GEO Fence Class // Find GEO Fence Transaction Date Range " + Ex.Message);
            }

            return aFindGEOFenceTransactionDateRangeDataSet;
        }
        public FindGEOFenceTransactionByExactDateDataSet FindGEOFenceTransaction(DateTime datEventDate, int intVehicleID)
        {
            try
            {
                aFindGEOFenceTransactionByExactDateDataSet = new FindGEOFenceTransactionByExactDateDataSet();
                aFindGEOFenceTransactionByExactDateTableAdapter = new FindGEOFenceTransactionByExactDateDataSetTableAdapters.FindGEOFenceTransactionByExactDateTableAdapter();
                aFindGEOFenceTransactionByExactDateTableAdapter.Fill(aFindGEOFenceTransactionByExactDateDataSet.FindGEOFenceTransactionByExactDate, datEventDate, intVehicleID);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "GEO Fence Class // Find GEO Fence Transaction " + Ex.Message);
            }

            return aFindGEOFenceTransactionByExactDateDataSet;
        }
        public bool InsertGEOFenceImportEntry(DateTime datEventDate, int intVehicleID, bool blnInSide, int intEmployeeID, string strDriver)
        {
            bool blnFatalError = false;

            try
            {
                aInsertGEOFenceImportTableAdapter = new InsertGEOFenceImportTansactionTableAdapters.QueriesTableAdapter();
                aInsertGEOFenceImportTableAdapter.InsertGEOFenceTransaction(datEventDate, intVehicleID, blnInSide, intEmployeeID, strDriver);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "GEO Fence Class // Insert GEO Fence Import Entry " + Ex.Message);

                blnFatalError = true;
            }

            return blnFatalError;
        }
        public GEOFenceImportDataSet GetGEOFenceImportInfo()
        {
            try
            {
                aGEOFenceImportDataSet = new GEOFenceImportDataSet();
                aGEOFenceImportTableAdapter = new GEOFenceImportDataSetTableAdapters.geofenceimportTableAdapter();
                aGEOFenceImportTableAdapter.Fill(aGEOFenceImportDataSet.geofenceimport);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "GEO Fence Class // Get GEO Fence Import Info " + Ex.Message);
            }

            return aGEOFenceImportDataSet;
        }
        public void UpdateGEOFenceImportDB(GEOFenceImportDataSet aGEOFenceImportDataSet)
        {
            try
            {
                aGEOFenceImportTableAdapter = new GEOFenceImportDataSetTableAdapters.geofenceimportTableAdapter();
                aGEOFenceImportTableAdapter.Update(aGEOFenceImportDataSet.geofenceimport);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "GEO Fence Class // Update GEO Fence Import DB " + Ex.Message);
            }
        }
    }
}
