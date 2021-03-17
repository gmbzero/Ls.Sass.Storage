using Microsoft.EntityFrameworkCore;
using SqlSugar;
using System;

namespace Ls.Sass.Storage.Web.Extensions
{
    /// <summary>
    /// 企业表
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:命名样式", Justification = "<挂起>")]
    public partial class tjs_company
    {
        /// <summary>
        /// Desc:公司ID;PK
        /// Nullable: false
        /// </summary>  
        [SugarColumn(IsPrimaryKey = true)]
        public long company_id { get; set; }

        /// <summary>
        /// Desc:公司名称
        /// Nullable: false
        /// </summary>  
        public string company_name { get; set; }

        /// <summary>
        /// Desc:公司简称
        /// Nullable: true
        /// </summary>  
        public string company_name_short { get; set; }

        /// <summary>
        /// Desc:所在省份ID
        /// Nullable: false
        /// </summary>  
        public long province_id { get; set; }

        /// <summary>
        /// Desc:所在省份名字
        /// Nullable: true
        /// </summary>  
        public string province_name { get; set; }

        /// <summary>
        /// Desc:所在城市ID
        /// Nullable: false
        /// </summary>  
        public long city_id { get; set; }

        /// <summary>
        /// Desc:所在城市名称
        /// Nullable: true
        /// </summary>  
        public string city_name { get; set; }

        /// <summary>
        /// Desc:营业执照
        /// Nullable: true
        /// </summary>  
        public string license { get; set; }

        /// <summary>
        /// Desc:是否已认证
        /// Default:(FALSE)
        /// Nullable: false
        /// </summary>  
        public bool is_certification { get; set; }

        /// <summary>
        /// Desc:审核状态;枚举：1=正常开放,2=关闭
        /// Default:(2)
        /// Nullable: false
        /// </summary>  
        public int audit_status { get; set; }

        /// <summary>
        /// Desc:所属行业ID
        /// Nullable: false
        /// </summary>  
        public long trade_id { get; set; }

        /// <summary>
        /// Desc:公司性质;枚举：民企=1,国企=2,中外合资=3,外商独资=4,行政机关=5,事业单位=6,社会团体=7,股份制企业=8,集体企业=9,其他=10
        /// Nullable: false
        /// </summary>  
        public int ecoclass { get; set; }

        /// <summary>
        /// Desc:融资情况;枚举：未融资=0 天使轮=1 A轮=2 B轮=3 C轮=4 D轮及以上=5 已上市=6 不需要融资=7
        /// Nullable: false
        /// </summary>  
        public int financing_situation { get; set; }

        /// <summary>
        /// Desc:员工规模
        /// Nullable: true
        /// </summary>  
        public string staff_scale { get; set; }

        /// <summary>
        /// Desc:成立时间
        /// Nullable: true
        /// </summary>  
        public string found_date { get; set; }

        /// <summary>
        /// Desc:Logo
        /// Nullable: true
        /// </summary>  
        public string logo { get; set; }

        /// <summary>
        /// Desc:公司网址
        /// Nullable: true
        /// </summary>  
        public string website { get; set; }

        /// <summary>
        /// Desc:公司介绍
        /// Nullable: true
        /// </summary>  
        public string introduction { get; set; }

        /// <summary>
        /// Desc:加入时间
        /// Nullable: false
        /// </summary>  
        public DateTime create_time { get; set; }

        /// <summary>
        /// Desc:上班时间;上班时间  24小时制
        /// Nullable: false
        /// </summary>  
        public DateTime on_duty_time { get; set; }

        /// <summary>
        /// Desc:下班时间;下班时间  24小时制
        /// Nullable: false
        /// </summary>  
        public DateTime off_duty_time { get; set; }

        /// <summary>
        /// Desc:周末休息状况;枚举：单休=0 双休=1 大小周=2 排版轮休=3
        /// Nullable: false
        /// </summary>  
        public int weekend { get; set; }

        /// <summary>
        /// Desc:加班情况;枚举：不加班=0 偶尔加班1 弹性加班=2
        /// Nullable: false
        /// </summary>  
        public int ot { get; set; }

        /// <summary>
        /// Desc:公司简介;公司简介 50字左右 与公司介绍不一样
        /// Nullable: true
        /// </summary>  
        public string synopsis { get; set; }

        /// <summary>
        /// Desc:免费查看简历期限
        /// Nullable: true
        /// </summary>  
        public DateTime see_resume_date { get; set; }

        /// <summary>
        /// Desc:免费查看简历次数
        /// Nullable: true
        /// </summary>  
        public int see_resume_number { get; set; }

        /// <summary>
        /// Desc:免费主动沟通期限
        /// Nullable: true
        /// </summary>  
        public DateTime chat_date { get; set; }

        /// <summary>
        /// Desc:免费主动沟通次数
        /// Nullable: true
        /// </summary>  
        public int chat_number { get; set; }

        /// <summary>
        /// Desc:来自那个服务入口;属于合作伙伴服务入口表
        /// Nullable: true
        /// </summary>  
        public long sid { get; set; }

        /// <summary>
        /// Desc:数据来源;枚举：自主注册=1,Boss直聘=2,58同城=3
        /// Default:(1)
        /// Nullable: false
        /// </summary>  
        public int data_from { get; set; }

    }

    public class UserRole
    {
        public Guid UserId { get; set; }

        public DateTime CreateTime { get; set; }

    }

    public class FonourDbContext : DbContext
    {
        public FonourDbContext(DbContextOptions<FonourDbContext> options) : base(options)
        {

        }

        public DbSet<UserRole> UserRole { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //UserRole关联配置
            builder.Entity<UserRole>().HasKey(ur => new { ur.UserId });

            base.OnModelCreating(builder);
        }
    }

    public interface IDBCom : IStorageContext
    {

        SimpleClient<tjs_company> Tjs_Company { get; }
    }

    public class DBCom : StorageContext, IDBCom
    {
        public DBCom(ISqlSugarClient sugarClient) : base(sugarClient) { }

        public SimpleClient<tjs_company> Tjs_Company => _sugarClient.GetSimpleClient<tjs_company>();
    }
}
