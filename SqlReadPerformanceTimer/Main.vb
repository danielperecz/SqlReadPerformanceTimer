Imports System.Data.SqlClient

Module Main

    Dim connectionString As String = "Data Source=DESKTOP-PJJIHHU;Initial Catalog=job_search_app;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"

    Sub Main()

        Console.WriteLine("Timing performance:")

        ' Timing SqlDataAdapter to DataTable.
        Dim timerStart As Date = Now
        Dim dt As DataTable = LoadData1()
        Dim timeSpent As TimeSpan = Now.Subtract(timerStart)
        Console.WriteLine("SqlDataAdapter to DataTable: " + timeSpent.ToString())

        ' Timing SqlDataReader to Dictionary.
        timerStart = Now
        Dim dict As Dictionary(Of Integer, Object()) = LoadData2()
        timeSpent = Now.Subtract(timerStart)
        Console.WriteLine("SqlDataReader to Dictionary: " + timeSpent.ToString())

        ' Timing SqlDataReader to HashSet.
        timerStart = Now
        Dim hs As HashSet(Of Integer) = LoadData3()
        timeSpent = Now.Subtract(timerStart)
        Console.WriteLine("   SqlDataReader to HashSet: " + timeSpent.ToString())

        Console.ReadLine()

    End Sub

    Private Function LoadData1() As DataTable
        ' Load data from SQL Server into a DataTable using SqlDataAdapter.

        Dim t As New DataTable
        Using con As New SqlConnection(connectionString)
            con.Open()
            Using da As New SqlDataAdapter("SELECT * FROM job_search_app.job_data.jobs", con)
                da.Fill(t)
            End Using
            con.Close()
        End Using

        Return t

    End Function

    Private Function LoadData2() As Dictionary(Of Integer, Object())
        ' Load data from SQL Server into a Dictionary using SqlDataReader.

        Dim t As New Dictionary(Of Integer, Object())
        Using con As New SqlConnection(connectionString), cmd As New SqlCommand("SELECT * FROM job_search_app.job_data.jobs", con)
            con.Open()
            Using rdr As SqlDataReader = cmd.ExecuteReader()
                While rdr.Read()
                    t.Add(key:=rdr(0), value:={
                          rdr(1),
                          rdr(2),
                          rdr(3),
                          rdr(4),
                          rdr(5),
                          rdr(6),
                          rdr(7),
                          rdr(8),
                          rdr(9),
                          rdr(10),
                          rdr(11),
                          rdr(12),
                          rdr(13),
                          rdr(14),
                          rdr(15),
                          rdr(16)
                          })
                End While
            End Using
            con.Close()
        End Using

        Return t

    End Function

    Private Function LoadData3() As HashSet(Of Integer)
        ' Load data from SQL Server into a HashSet using SqlDataReader.

        Dim t As New HashSet(Of Integer)
        Using con As New SqlConnection(connectionString), cmd As New SqlCommand("SELECT * FROM job_search_app.job_data.jobs", con)
            con.Open()
            Using rdr As SqlDataReader = cmd.ExecuteReader()
                While rdr.Read()
                    t.Add(rdr(0))
                End While
            End Using
            con.Close()
        End Using

        Return t

    End Function

End Module
