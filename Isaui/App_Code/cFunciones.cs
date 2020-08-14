using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using CapaDatos;
/// <summary>
/// Summary description for cFunciones
/// </summary>
public static class cFunciones
{
    public cFunciones()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public static void LlenarCombo(DropDownList Combo, string Tabla, string Texto, string Value)
    {
        string sql = " select * from " + Tabla;
        sql = sql + " order by " + Texto;
        DataTable trdo = cDb.GetDatos(sql);
        DataTable trdo2 = new DataTable();
        trdo2.Columns.Add(Value);
        trdo2.Columns.Add(Texto);

        DataRow r = trdo2.NewRow();
        r[0] = 0;
        r[1] = "---Seleccionar---";
        trdo2.Rows.Add(r);
        for (int i = 0; i < trdo.Rows.Count; i++)
        {
            DataRow r2 = trdo2.NewRow();
            r2[Value] = trdo.Rows[i][Value];
            r2[Texto] = trdo.Rows[i][Texto];
            trdo2.Rows.Add(r2);
        }
        Combo.DataSource = trdo2;
        Combo.DataTextField = Texto;
        Combo.DataValueField = Value;
        Combo.DataBind();
    }

    public static void LlenarComboDatatable(DropDownList Combo, DataTable trdo, string Texto, string Value)
    {
        DataTable trdo2 = new DataTable();
        trdo2.Columns.Add(Value);
        trdo2.Columns.Add(Texto);

        DataRow r = trdo2.NewRow();
        r[0] = 0;
        r[1] = "---Seleccionar---";
        trdo2.Rows.Add(r);
        for (int i = 0; i < trdo.Rows.Count; i++)
        {
            DataRow r2 = trdo2.NewRow();
            r2[Value] = trdo.Rows[i][Value];
            r2[Texto] = trdo.Rows[i][Texto];
            trdo2.Rows.Add(r2);
        }
        Combo.DataSource = trdo2;
        Combo.DataValueField = Value;
        Combo.DataTextField = Texto;
        Combo.DataBind();
        Combo.SelectedIndex = 0;
    }
}