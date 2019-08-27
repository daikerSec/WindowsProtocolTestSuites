// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.


namespace Microsoft.Protocols.TestTools.StackSdk.FileAccessService.WSP.Adapter
{
    /// <summary>
    /// IWspAdapter interface describes the methods
    /// for Windows Search Protocol.
    /// </summary>
    public interface IWspAdapter : IAdapter
    {
        /// <summary>
        /// Get server's OS version
        /// </summary>
        /// <param name="platform">Represent server's platform type</param>
        /// <returns>The call must return true which indicates success</returns>
        bool GetServerPlatform(out SkuOsVersion platform);

        # region WSP requests

        /// <summary>
        /// CPMConnectInRequest() is used to send a request 
        /// to establish a connection with the server
        /// and starts WSP query processing or WSP catalog administration.
        /// </summary>
        void CPMConnectInRequest();      

        /// <summary>
        /// CPMCreateQueryIn(DBPROP_ENABLEROWSETEVENTS) emulates WSP CPMCreateQueryIn 
        /// message and associates a query with the client with DBPROP_ENABLEROWSETEVENTS as set
        /// if successful
        /// </summary>
        void CPMCreateQueryIn(bool ENABLEROWSETEVENTS);

        /// <summary>
        /// CPMGetQueryStatusIn() requests the status of the query.
        /// </summary>
        /// <param name="isCursorValid">Indicates the client 
        /// has a valid cursor to the query.</param>
        void CPMGetQueryStatusIn(bool isCursorValid);
        /// <summary>
        /// CPMGetQueryStatusExIn()requests for the status of the
        /// query and the additional information from the server.
        /// </summary>
        /// <param name="isCursorValid">Indicates the client 
        /// has a valid cursor to the query.</param>
        void CPMGetQueryStatusExIn(bool isCursorValid);
        /// <summary>
        /// CPMRatioFinishedIn() requests for the completion 
        /// percentage of the query.
        /// </summary>
        /// <param name="isCursorValid">Indicates the client 
        /// has a valid cursor to the query.</param>
        void CPMRatioFinishedIn(bool isCursorValid);
        /// <summary>
        /// CPMSetBindingsIn() requests the bindings of columns to a rowset.
        /// </summary>
        /// <param name="isValidBindingInfo">Indicates whether it 
        /// is a valid Binding</param>
        /// <param name="isCursorValid">Indicates the client 
        /// has a valid cursor to the query.</param>
        void CPMSetBindingsIn(bool isValidBindingInfo, bool isCursorValid);
        /// <summary>
        /// CPMGetRowsIn() message requests rows from a query.
        /// </summary>
        /// <param name="isCursorValid">Indicates the client 
        /// has a valid cursor to the query.</param>
        void CPMGetRowsIn(bool isCursorValid);
        /// <summary>
        /// CPMFetchValueIn() requests for the property value
        /// that was too large to return in a rowset.
        /// </summary>
        /// <param name="isCursorValid">Indicates the client 
        /// has a valid cursor to the query.</param>
        void CPMFetchValueIn(bool isCursorValid);
        /// <summary>
        /// CPMCiStateInOut() requests the information about 
        /// the state of the Windows Search Service.
        /// </summary>
        void CPMCiStateInOut();
        /// <summary>
        /// CPMGetNotifyIn() requests that the client wants to be notified
        /// of rowset changes.
        /// </summary>
        /// <param name="isCursorValid">Indicates the client 
        /// has a valid cursor to the query.</param>
        void CPMGetNotify(bool isCursorValid);
        /// <summary>
        /// CPMFreeCursorIn() requests to release a cursor.
        /// </summary>
        /// <param name="isCursorValid">Indicates the client 
        /// has a valid cursor to the query.</param>
        void CPMFreeCursorIn(bool isCursorValid);
        /// <summary>
        /// CPMDisconnect() request is sent to end 
        /// the connection with the server.
        /// </summary>
        void CPMDisconnect();

        /// <summary>
        /// CPMFindIndicesIn() request the rowset position of the next occurrence of a document identifier
        /// </summary>
        /// <param name="isCursorValid"></param>
        void CPMFindIndicesIn(bool isCursorValid);

        /// <summary>
        /// CPMGetRowsetNotifyIn message requests the next rowset event from the server if available
        /// </summary>
        /// <param name="eventType"></param>
        /// <param name="moreEvent"></param>
        void CPMGetRowsetNotifyIn(int eventType,bool moreEvent);

        /// <summary>
        /// CPMSetScopePrioritizationIn() request that server prioritize indexing of items that may be relevant to the originating query
        /// at a rate specified in the message
        /// </summary>
        /// <param name="priority"></param>
        void CPMSetScopePrioritizationIn(uint priority);

        /// <summary>
        /// CPMGetScopeStatisticsIn() request that statistics regarding the number of indexed items
        /// </summary>
        void CPMGetScopeStatisticsIn();

        /// <summary>
        /// CPMUpdateDocumentsIn() request directs the server to index the specified path
        /// </summary>
        /// <param name="_flag"></param>
        /// <param name="_fRootPath"></param>
        void CPMUpdateDocumentsIn(uint _flag, uint _fRootPath);

        # endregion

        # region Event Handlers

        /// <summary>
        /// This event is used to get the response from CPMConnectIn request.
        /// </summary>
        event CPMConnectOutResponseHandler CPMConnectOutResponse;

        /// <summary>
        /// This event is used to get the response 
        /// from CPMCreateQueryIn request.
        /// </summary>
        event CPMCreateQueryOutResponseHandler 
            CPMCreateQueryOutResponse;

        /// <summary>
        /// This event is used to get the response 
        /// from CPMGetQueryStatusIn request.
        /// </summary>
        event CPMGetQueryStatusOutResponseHandler
            CPMGetQueryStatusOutResponse;

        /// <summary>
        /// This event is used to get the response 
        /// from CPMGetQueryStatusExIn request.
        /// </summary>
        event CPMGetQueryStatusExOutResponseHandler
            CPMGetQueryStatusExOutResponse;

        /// <summary>
        /// This event is used to get the response
        /// from CPMRatioFinishedIn request.
        /// </summary>
        event CPMRatioFinishedOutResponseHandler CPMRatioFinishedOutResponse;

        /// <summary>
        /// This event is used to get the 
        /// response from CPMSetBindingsIn request.
        /// </summary>
        event CPMSetBindingsInResponseHandler CPMSetBindingsInResponse;

        /// <summary>
        /// This event is used to get the response from CPMGetRowsIn request.
        /// </summary>
        event CPMGetRowsOutResponseHandler CPMGetRowsOut;

        /// <summary>
        /// This event is used to get the response
        /// from CPMFetchValueIn request.
        /// </summary>
        event CPMFetchValueOutResponseHandler CPMFetchValueOutResponse;

        /// <summary>
        /// This event is used to get the response 
        /// from CPMCiStateInOut request.
        /// </summary>
        event CPMCiStateInOutResponseHandler CPMCiStateInOutResponse;

        /// <summary>
        /// This event is used to get the response from CPMGetNotify request.
        /// </summary>
        event CPMSendNotifyOutResponseHandler CPMSendNotifyOutResponse;

        /// <summary>
        /// This event is used to get the response from CPMFreeCursorIn request.
        /// </summary>
        event CPMFreeCursorOutResponseHandler CPMFreeCursorOutResponse;

        /// <summary>
        /// This event is used to get the response from CPMFindIndicesIn request.
        /// </summary>
        event CPMFindIndicesOutResponseHandler CPMFindIndicesOutResponse;

        /// <summary>
        /// This event is used to get the response from CPMGetRowsetNotifyIn request.
        /// </summary>
        event CPMGetRowsetNotifyOutResponseHandler CPMGetRowsetNotifyOutResponse;

        /// <summary>
        /// This event is used to get the response from CMPGetScopeStatisticsIn request.
        /// </summary>
        event CPMGetScopeStatisticsOutResponseHandler CPMGetScopeStatisticsOutResponse;

        /// <summary>
        /// This event is used to get the response from CPMSetScopePrioritizationIn request.
        /// </summary>
        event CPMSetScopePrioritizationOutResponseHandler CPMSetScopePrioritizationOutResponse;

        /// <summary>
        /// This event is used to get the response from CPMUpdateDocumentsIn request.
        /// </summary>
        event CPMUpdateDocumentsOutResponseHandler CPMUpdateDocumentsOutResponse;

        # endregion
    }

    # region Delegates

    /// <summary>
    /// CPMConnectOutResponseHandler is a delegate
    /// for CPMConnectOutResponse event.
    /// </summary>
    /// <param name="errorCode">Error code  
    /// from the server response.</param>
    public delegate void CPMConnectOutResponseHandler(uint errorCode);

    /// <summary>
    /// CPMCreateQueryOutResponseHandler is a delegate
    /// for CPMCreateQueryOutResponse event.
    /// </summary>
    /// <param name="errorCode">Error code  
    /// from the server response.</param>
    public delegate void CPMCreateQueryOutResponseHandler(uint errorCode);

    /// <summary>
    /// CPMGetQueryStatusOutResponseHandler is a delegate 
    /// for CPMGetQueryStatusOutResponse event.
    /// </summary>
    /// <param name="errorCode">Error code  
    /// from the server response.</param>
    public delegate void CPMGetQueryStatusOutResponseHandler(uint errorCode);

    /// <summary>
    /// CPMGetQueryStatusExOutResponseHandler is a delegate
    /// for CPMGetQueryStatusExOutResponse event.
    /// </summary>
    /// <param name="errorCode">Error code from the server response.</param>
    public delegate void CPMGetQueryStatusExOutResponseHandler(uint errorCode);

    /// <summary>
    /// CPMRatioFinishedOutResponseHandler is a delegate
    /// for CPMRatioFinishedOutResponse event.
    /// </summary>
    /// <param name="errorCode">Error code  from the server response.</param>
    public delegate void CPMRatioFinishedOutResponseHandler(uint errorCode);

    /// <summary>
    /// CPMSetBindingsInResponseHandler is a delegate
    /// for CPMSetBindingsInResponse event.
    /// </summary>
    /// <param name="errorCode">Error code from the server response.</param>
    public delegate void CPMSetBindingsInResponseHandler(uint errorCode);

    /// <summary>
    /// CPMGetRowsOutResponseHandler is a delegate
    /// for CPMGetRowsOutResponse event.
    /// </summary>
    /// <param name="errorCode">Error code from the server response.</param>
    public delegate void CPMGetRowsOutResponseHandler(uint errorCode);

    /// <summary>
    /// CPMFetchValueOutResponseHandler is a delegate
    /// for CPMFetchValueOutResponse event.
    /// </summary>
    /// <param name="errorCode">Error code from the server response.</param>
    public delegate void CPMFetchValueOutResponseHandler(uint errorCode);

    /// <summary>
    /// CPMCiStateInOutResponseHandler is a delegate 
    /// for CPMCiStateInOutResponse event.
    /// </summary>
    /// <param name="errorCode">Error code from the server response.</param>
    public delegate void CPMCiStateInOutResponseHandler(uint errorCode);

    /// <summary>
    /// CPMForceMergeInResponseHandler is a delegate 
    /// for CPMForceMergeInResponse event.
    /// </summary>
    /// <param name="errorCode">Error code from the server response.</param>
    public delegate void CPMForceMergeInResponseHandler(uint errorCode);

    /// <summary>
    /// CPMSendNotifyOutResponseHandler is a delegate 
    /// for CPMSendNotifyOutResponse event.
    /// </summary>
    /// <param name="errorCode">Error code from the server response.</param>
    public delegate void CPMSendNotifyOutResponseHandler(uint errorCode);

    /// <summary>
    /// CPMFreeCursorOutResponseHandler is a delegate 
    /// for CPMFreeCursorOutResponse event.
    /// </summary>
    /// <param name="errorCode">Error code from the server response.</param>
    public delegate void CPMFreeCursorOutResponseHandler(uint errorCode);

    /// <summary>
    /// CPMFindIndicesOutResponseHandler is a delegate 
    /// for CPMFindIndicesOutResponse event.
    /// </summary>
    /// <param name="errorCode"></param>
    public delegate void CPMFindIndicesOutResponseHandler(uint errorCode);

    /// <summary>
    /// CPMGetRowsetNotifyOutResponseHandler is a delegate 
    /// for CPMGetRowsetNotifyOutResponse event.
    /// </summary>
    /// <param name="errorCode"></param>
    public delegate void CPMGetRowsetNotifyOutResponseHandler(uint errorCode);

    /// <summary>
    /// CPMSetScopePrioritizationOutResponseHandler is a delegate 
    /// for CPMSetScopePrioritizationOutResponse event.
    /// </summary>
    /// <param name="errorCode"></param>
    public delegate void CPMSetScopePrioritizationOutResponseHandler(uint errorCode);

    /// <summary>
    /// CPMGetScopeStatisticsOutResponseHandler is a delegate 
    /// for CPMGetScopeStatisticsOutResponse event.
    /// </summary>
    /// <param name="errorCode">Error code from the server response.</param>
    public delegate void CPMGetScopeStatisticsOutResponseHandler(uint errorCode);

    /// <summary>
    /// CPMUpdateDocumentsOutResponseHandler is a delegate 
    /// for CPMUpdateDocumentsOutResponse event.
    /// </summary>
    /// <param name="errorCode"></param>
    public delegate void CPMUpdateDocumentsOutResponseHandler(uint errorCode);


    # endregion
}
