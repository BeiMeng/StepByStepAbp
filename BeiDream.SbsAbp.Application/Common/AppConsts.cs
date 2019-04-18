using System;
using System.Collections.Generic;
using System.Text;

namespace BeiDream.SbsAbp.Common
{
    public class AppConsts
    {
        /// <summary>
        /// Default page size for paged requests.
        /// </summary>
        public const int DefaultPageSize = 10;

        /// <summary>
        /// Maximum allowed page size for paged requests.
        /// </summary>
        public const int MaxPageSize = 1000;


        /// <summary>
        /// Default pass phrase for SimpleStringCipher decrypt/encrypt operations
        /// </summary>
        public const string DefaultPassPhrase = "gsKxGZ012HLL3MI5";

        /// <summary>
        /// 生成jwt token 的 验证 key 标识
        /// </summary>
        public const string TokenValidityKey = "token_validity_key";

 
        /// <summary>
        /// 生成jwt token 添加的 登陆用户信息 的 标识
        /// </summary>
        public static string UserIdentifier = "user_identifier";

        /// <summary>
        /// jwt token 过期时间
        /// </summary>
        public static TimeSpan AccessTokenExpiration = TimeSpan.FromHours(3);
    }
}
