﻿// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Protocols.TestTools.StackSdk.BranchCache.Pccrr
{
    using System;
    using System.Collections.Generic;
    using Microsoft.Protocols.TestTools.StackSdk.CommonStack;

    /// <summary>
    /// The PccrrGETBLKSRequestPacket is sent by the client.
    /// </summary>
    public class PccrrGETBLKSRequestPacket : PccrrPacket
    {
        /// <summary>
        /// http requesting URI
        /// </summary>
        private Uri uri;

        /// <summary>
        /// http requesting method
        /// </summary>
        private HttpMethod method;

        /// <summary>
        /// The messageHeader
        /// </summary>
        private MESSAGE_HEADER messageHeader;

        /// <summary>
        /// The msgGetBLKS
        /// </summary>
        private MSG_GETBLKS msgGetBLKS;

        /// <summary>
        /// Initializes a new instance of the <see cref="PccrrGETBLKSRequestPacket"/> class.
        /// </summary>
        public PccrrGETBLKSRequestPacket()
        {
        }

        /// <summary>
        /// Gets or sets the http requesting URI.
        /// </summary>
        public Uri Uri
        {
            get
            {
                return this.uri;
            }

            set
            {
                this.uri = value;
            }
        }

        /// <summary>
        /// Gets or sets the http requesting method.
        /// </summary>
        public HttpMethod Method
        {
            get
            {
                return this.method;
            }

            set
            {
                this.method = value;
            }
        }

        /// <summary>
        /// Get the type of the packet.
        /// </summary>
        /// <returns>The type of the packet.</returns>
        public override MsgType_Values PacketType
        {
            get
            {
                return MsgType_Values.MSG_GETBLKS;
            }
        }

        /// <summary>
        /// Gets or sets the MessageHeader.
        /// </summary>
        public MESSAGE_HEADER MessageHeader
        {
            get
            {
                return this.messageHeader;
            }

            set
            {
                this.messageHeader = value;
            }
        }

        /// <summary>
        /// Gets or sets the MsgGetBLKS.
        /// </summary>
        public MSG_GETBLKS MsgGetBLKS
        {
            get
            {
                return this.msgGetBLKS;
            }

            set
            {
                this.msgGetBLKS = value;
            }
        }

        /// <summary>
        /// Encode pack.
        /// </summary>
        /// <returns>Encode bytes.</returns>
        public override byte[] Encode()
        {
            REQUEST_MESSAGE requestMessage = new REQUEST_MESSAGE();
            requestMessage.MESSAGEBODY = this.msgGetBLKS;
            requestMessage.MESSAGEHEADER = this.MessageHeader;
            byte[] ret;

            List<byte> temp = new List<byte>();
            byte[] tempPayload;

            List<byte> listRet = new List<byte>();
            listRet.AddRange(MarshalHelper.GetBytes(((MSG_GETBLKS)requestMessage.MESSAGEBODY).SizeOfSegmentID, false));
            listRet.AddRange(((MSG_GETBLKS)requestMessage.MESSAGEBODY).SegmentID);
            while (listRet.Count % 4 != 0)
            {
                listRet.Add(byte.MinValue);
            }

            listRet.AddRange(MarshalHelper.GetBytes(((MSG_GETBLKS)requestMessage.MESSAGEBODY).ReqBlockRangeCount, false));
            for (int i = 0; i < ((MSG_GETBLKS)requestMessage.MESSAGEBODY).ReqBlockRanges.Length; i++)
            {
                listRet.AddRange(MarshalHelper.GetBytes(((MSG_GETBLKS)requestMessage.MESSAGEBODY).ReqBlockRanges[i].Index, false));
                listRet.AddRange(MarshalHelper.GetBytes(((MSG_GETBLKS)requestMessage.MESSAGEBODY).ReqBlockRanges[i].Count, false));
            }

            listRet.AddRange(MarshalHelper.GetBytes(((MSG_GETBLKS)requestMessage.MESSAGEBODY).SizeOfDataForVrfBlock, false));
            tempPayload = listRet.ToArray();

            requestMessage.MESSAGEHEADER.MsgSize = (uint)tempPayload.Length + 16;

            List<byte> listRet1 = new List<byte>();
            listRet1.AddRange(MarshalHelper.GetBytes((ushort)requestMessage.MESSAGEHEADER.ProtVer.MinorVersion, false));
            listRet1.AddRange(MarshalHelper.GetBytes((ushort)requestMessage.MESSAGEHEADER.ProtVer.MajorVersion, false));
            listRet1.AddRange(MarshalHelper.GetBytes((uint)requestMessage.MESSAGEHEADER.MsgType, false));
            listRet1.AddRange(MarshalHelper.GetBytes(requestMessage.MESSAGEHEADER.MsgSize, false));
            listRet1.AddRange(MarshalHelper.GetBytes((uint)requestMessage.MESSAGEHEADER.CryptoAlgoId, false));

            temp.AddRange(listRet1.ToArray());
            temp.AddRange(tempPayload);
            ret = (byte[])temp.ToArray();

            return ret;
        }

        /// <summary>
        /// Decode pack.
        /// </summary>
        /// <param name="rawdata">The rawdata.</param>
        /// <returns>The PccrrPacket.</returns>
        public override PccrrPacket Decode(byte[] rawdata)
        {
            throw new NotImplementedException();
        }
    }
}
