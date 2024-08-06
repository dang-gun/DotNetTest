
namespace EntityFrameworkSample.DB.MultiMigrations;

/// <summary>
/// Sqlite DB 미리 저장한 기본 정보
/// </summary>
public class DbContextDefaultInfo_Sqlite : DbContextDefaultInfoInterface
{
    /// <inheritdoc />
    public UseDbType DBType { get; set; } = UseDbType.SQLite;
    /// <inheritdoc />
    public string DBString { get; set; } = "Data Source=Test.db";

    /// <inheritdoc />
    /// <remarks>
    /// 강제로 UseDbType.SQLite로 변경된다.
    /// </remarks>
    public void ReSetting()
    {
        GlobalDb.DBType = this.DBType;

        if (string.Empty == GlobalDb.DBString)
        {//기존 DBType과 다르다.
         //DB 연결 문자열 정보가 없다.

            //DB 연결정보를 다시 불러온다.
            DbContextDefaultInfo_Sqlite newDbInfo = new DbContextDefaultInfo_Sqlite();
            GlobalDb.DBString = newDbInfo.DBString;
        }

        
    }
}
