# SqlReadPerformanceTimer
A mini console app for testing different ways of reading and storing data from SQL Server into VB.NET (which probably also applies to C#). Source file is at `SqlReadPerformanceTimer/Main.vb`.

## Results
| Read Method    | -> | Data Type                        | Time             |
|----------------|----|----------------------------------|------------------|
| SqlDataAdapter | -> | DataTable                        | 00:00:00.1300412 |
| SqlDataReader  | -> | Dictionary(Of Integer, Object()) | 00:00:00.0945076 |
| SqlDataReader  | -> | HashSet(Of Integer)              | 00:00:00.0365661 |

Something interesting regarding the `ToString()` method is that it seems to be very slow because when I used a `Dictionary(Of Integer, String())` and had to convert each object into a string, it added approximately an extra 10% of execution time.
