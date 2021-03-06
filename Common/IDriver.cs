﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DrBAE.Congress.Common
{
    public interface IDriver
    {
        Vote[] GetVoteData(bool fromServer);
        Party[] GetPartyData(bool fromServer);


        void SaveParty(Party[] paties, bool toServer = false);
        void SaveVote(Vote[] paties, bool toServer = false);

    }
}
