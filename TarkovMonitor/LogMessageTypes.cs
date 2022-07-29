﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TarkovMonitor
{
    public class LogMessage
    {
        public string type { get; set; }
        public string eventId { get; set; }
    }

    public class NewMessage : LogMessage
    {
        public string dialogId { get; set; }
        public ChatMessage message { get; set; }
    }
    public class ChatMessage
    {
        public string _id { get; set; }
        public string uid { get; set; }
        public int type { get; set; }
        public int dt { get; set; }
        public string text { get; set; }
        public string templateId { get; set; }
        public bool hasRewards { get; set; }
        public int maxStorageTime { get; set; }
        public MessageAttachments? items { get; set; }
        public Dictionary<string, string>? systemData { get; set; }
    }
    public class FleaSoldNewMessage : LogMessage
    {
        public new FleaSoldChatMessage message { get; set; }
    }
    public class FleaSoldChatMessage : ChatMessage
    {
        public new FleaSoldData systemData { get; set; }
    }
    public class FleaSoldData
    {
        public string buyerNickname { get; set; }
        public string soldItem { get; set; }
        public int itemCount { get; set; }
    }
    public class MessageAttachments
    {
        public string stash { get; set; }
        public List<MessageAttachment> data { get; set; }
    }
    public class MessageAttachment
    {
        public string _id { get; set; }
        public string _tpl { get; set; }
        public ItemAttachmentCount upd { get; set; }
        public string parentId { get; set; }
        public string slotId { get; set; }
    }
    public class ItemAttachmentCount
    {
        public int StackObjectsCount { get; set; }
    }
    public class UserConfirmed : LogMessage
    {
        public string profileid { get; set; }
        public string profileToken { get; set; }
        public string status { get; set; }
        public string ip { get; set; }
        public int port { get; set; }
        public string sid { get; set; }
        public string version { get; set; }
        public string location { get; set; }
        public string raidMode { get; set; }
        public string mode { get; set; }
        public string shortId { get; set; }
        public string[] additiona_info { get; set; }
    }

    public class GroupMatchInviteAccept : LogMessage
    {
        public string _id { get; set; }
        public int aid { get; set; }
        public PlayerInfo Info { get; set; }
        public PlayerLoadout PlayerVisualRepresentation { get; set; }
    }
    public class GroupMatchInviteSend : LogMessage
    {
        public string groupId { get; set; }
        public int dt { get; set; }
        public string from { get; set; }
        public string to { get; set; }

        public GroupMatchInviteSendProfile fromProfile { get; set; }
    }
    public class PlayerInfo
    {
        public string Side { get; set; }
        public int Level { get; set; }
        public string Nickname { get; set; }
        public int MemberCategory { get; set; }
    }
    public class PlayerLoadout
    {
        public PlayerInfo Info { get; set; }
        public PlayerEquipment Equipment { get; set; }
        public PlayerClothes Customization { get; set; }
    }
    public class PlayerEquipment
    {
        public string Id { get; set; }
        public LoadoutItem[] Items { get; set; }
    }
    public class LoadoutItem
    {
        public string _id { get; set; }
        public string _tpl { get; set; }
        public string? parentId { get; set; }
        public string? slotId { get; set; }
        public LoadoutItemLocation? location { get; set; }
        public LoadoutItemProperties? upd { get; set; }
        public string? name { get; set; }
        public override string ToString()
        {
            var displayName = this._tpl;
            if (this.name != null) displayName = this.name;
            if (this.upd?.StackObjectsCount > 1) displayName += $" (x{this.upd.StackObjectsCount})";
            if (this.upd?.Repairable != null) displayName += $" ({Math.Round(this.upd.Repairable.Durability, 2)}/{this.upd.Repairable.MaxDurability})";
            return displayName;
        }
    }
    public class LoadoutItemLocation
    {
        public int x { get; set; }
        public int y { get; set; }
        public int r { get; set; }
        public bool isSearched { get; set; }
    }
    public class LoadoutItemProperties
    {
        public LoadoutItemPropertiesDurability? Repairable { get; set; }
        public LoadoutItemPropertiesMeds? MedKit { get; set; }
        public LoadoutItemPropertiesFoodDrink? FoodDrink { get; set; }
        public LoadoutItemPropertiesFireMode? FireMode { get; set; }
        public LoadoutItemPropertiesScope? Sight { get; set; }
        public LoadoutItemPropertiesResource? Resource { get; set; }
        public LoadoutItemPropertiesDogtag? Dogtag { get; set; }
        public int? StackObjectsCount { get; set; }
        public bool? SpawnedInSession { get; set; }
    }
    public class LoadoutItemPropertiesDurability
    {
        public float MaxDurability { get; set; }
        public float Durability { get; set; }
    }
    public class LoadoutItemPropertiesMeds
    {
        public int HpResource { get; set; }
    }
    public class LoadoutItemPropertiesFoodDrink
    {
        public int HpPercent { get; set; }
    }
    public class LoadoutItemPropertiesFireMode
    {
        public string FireMode { get; set; }
    }
    public class LoadoutItemPropertiesScope
    {
        public int[] ScopesCurrentCalibPointIndexes { get; set; }
        public int[] ScopesSelectedModes { get; set; }
        public int SelectedScope { get; set; }
    }
    public class LoadoutItemPropertiesResource
    {
        public int Value { get; set; }
    }
    public class LoadoutItemPropertiesDogtag
    {
        public string AccountId { get; set; }
        public string ProfileId { get; set; }
        public string Side { get; set; }
        public int Level { get; set; }
        public string Time { get; set; }
        public string Status { get; set; }
        public string KillerAccountId { get; set; }
        public string KillerProfileId { get; set; }
        public string KillerName { get; set; }
        public string WeaponName { get; set; }
    }
    public class PlayerClothes
    {
        public string Head { get; set; }
        public string Body { get; set; }
        public string Feet { get; set; }
        public string Hands { get; set; }
    }
    public class GroupMatchInviteSendProfile
    {
        public string _id { get; set; }
        public int aid { get; set; }
        public PlayerInfo Info { get; set; }
        public PlayerLoadout PlayerVisualRepresentation { get; set; }
    }
}
