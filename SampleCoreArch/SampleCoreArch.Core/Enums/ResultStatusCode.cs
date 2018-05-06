namespace SampleCoreArch.Core.Enums
{
    /// <summary>
    /// İş katmanında işlem sonuçlarının işlem kodu için kullanılır.
    /// </summary>
    public enum ResultStatusCode
    {
        /// <summary>
        /// Başarılı
        /// </summary>
        Ok = 200,
        /// <summary>
        /// Yetki Sorunu
        /// </summary>
        Unauthorized = 401,
        /// <summary>
        /// Yasak
        /// </summary>
        Forbidden = 403,
        /// <summary>
        /// Bulunamadı
        /// </summary>
        NotFound = 404,
        /// <summary>
        /// Sunucu Hatası
        /// </summary>
        InternalServerError = 500,
        /// <summary>
        /// Kayıt Bulunamadı
        /// </summary>
        ExistingItem = 600,
        /// <summary>
        /// Uyarı
        /// </summary>
        Warning = 700,
        /// <summary>
        /// Bilgilendirme
        /// </summary>
        Info = 800
    }
}