Imports System
Imports System.Data
Imports System.Data.Odbc
Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports ClaseConexion
Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols

' Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente.
<System.Web.Script.Services.ScriptService()> _
<WebService(Namespace:="http://tempuri.org/")> _
<WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Public Class WSConsultaReniec
    Inherits System.Web.Services.WebService

    <WebMethod()> _
    Public Function Datos_Persona(ByVal dni As String) As DataTable
        Dim cmd As New SqlCommand
        Dim CN As New ClaseConexion
        Dim da As New SqlDataAdapter("usp_DatosPersona", CN.getconexion)

        da.SelectCommand.CommandType = CommandType.StoredProcedure

        da.SelectCommand.Parameters.Add("@dni", SqlDbType.Char).Value = dni
        Dim dts As New DataSet
        da.Fill(dts, "persona")
        Return dts.Tables("persona")
    End Function

End Class