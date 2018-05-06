using SampleCoreArch.Core.Enums;

namespace SampleCoreArch.Core.Common
{
    /// <summary>
    /// Data katmanı ile iş katmanı arasındaki veri akışını generic hale getirmek için kullanılır
    /// </summary>
    /// <typeparam name="T">İş katmanınızdaki geriye dönen model ne ise o tipde sınıf alır</typeparam>
    public class Result<T>
    {
        /// <summary>
        /// Default olarak ResultCode,ResultStatus değerlerine atama yapılır
        /// </summary>
        public Result()
        {
            ResultStatus = true;
            ResultCode = (int) ResultStatusCode.Ok;
            ResultMessage = ResultStatusCode.Ok.ToString();
        }

        /// <summary>
        /// İş katmanınızdan dönen veriye erişmenizi sağlar
        /// </summary>
        public T ResultObject { get; set; }

        /// <summary>
        /// İş katmanınızdaki veriye erişirken hata oluşması durumunda ya da iş kuralı sırasında uyarı mesajı kullanıcıya gösterilmek istenirse bu alana set edilir 
        /// </summary>
        public string ResultMessage { get; set; }

        /// <summary>
        /// İş katmanınızda daha detaylı bir mesaj dönmek isterseniz bu alana set edilir
        /// </summary>
        public string ResultInnerMessage { get; set; }

        /// <summary>
        /// İş katmanınızda işlem o anki işlem yapılırken işlemin durumu başarılı/başarısız bu alana set edilir
        /// </summary>
        public bool ResultStatus { get; set; }

        /// <summary>
        /// İş katmanınızda işlem o anki işlem yapılırken işlemin durumu ResultStatusCode enum tanımları işinden belirlenerek bu alana set edilir
        /// </summary>
        public int ResultCode { get; set; }
    }
}