using System;

namespace VkLib.Core.Auth
{
    /// <summary>
    /// Права доступа приложения
    /// </summary>
    [Flags]
    public enum VkScopeSettings
    {
        /// <summary>
        /// Пользователь разрешил отправлять ему уведомления. 
        /// </summary>
        notify = 1,
        /// <summary>
        /// Доступ к друзьям.
        /// </summary>
        friends = 2,
        /// <summary>
        /// Доступ к фотографиям. 
        /// </summary>
        photos = 4,
        /// <summary>
        /// Доступ к аудиозаписям. 
        /// </summary>
        audio = 8,
        /// <summary>
        /// Доступ к видеозаписям. 
        /// </summary>
        video = 16,
        /// <summary>
        /// Доступ к статусу пользователя.
        /// </summary>
        status = 1024,
        /// <summary>
        /// Доступ к предложениям (устаревшие методы). 
        /// </summary>
        offers = 32,
        /// <summary>
        /// Доступ к вопросам (устаревшие методы). 
        /// </summary>
        questions = 64,
        /// <summary>
        /// Доступ к wiki-страницам. 
        /// </summary>
        pages = 128,
        /// <summary>
        /// Добавление ссылки на приложение в меню слева.
        /// </summary>
        link = 256,
        /// <summary>
        /// Доступ заметкам пользователя. 
        /// </summary>
        notes = 2048,
        /// <summary>
        /// (для Standalone-приложений) Доступ к расширенным методам работы с сообщениями. 
        /// </summary>
        messages = 4096,
        /// <summary>
        /// Доступ к обычным и расширенным методам работы со стеной. 
        /// </summary>
        wall = 8192,
        /// <summary>
        /// Доступ к документам пользователя.
        /// </summary>
        docs = 131072,
        /// <summary>
        /// Доступ к группам пользователя.
        /// </summary>
        groups = 262144,
        /// <summary>
        /// Доступ к оповещениям об ответах пользователю.
        /// </summary
        notifications = 524288,
        /// <summary>
        /// Доступ к API в любое время со стороннего сервера
        /// </summary
        offline = 65536,
        /// <summary>
        /// God mode (offline доступ)
        /// </summary>
        IamTheGod = 999999 //вечный токен
    }
}
