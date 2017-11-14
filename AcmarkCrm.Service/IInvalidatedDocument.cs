using System;

namespace AcmarkCrm.Service
{
    /// <summary>
    /// 
    /// </summary>
    public interface IInvalidatedDocument
    {
        /// <summary>
        /// 
        /// </summary>
        string DocumentId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        DateTime InvalidationDate { get; set; }
    }
}