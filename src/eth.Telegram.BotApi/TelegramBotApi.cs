﻿//Telegram Bot API v2.1
//for details: https://core.telegram.org/bots/api
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using eth.Common;
using eth.Common.JetBrains.Annotations;
using eth.Telegram.BotApi.Internal;
using eth.Telegram.BotApi.Objects;

namespace eth.Telegram.BotApi
{
    public class TelegramBotApi : ITelegramBotApi, IHttpClientTimeout, IDisposable
    {
        private readonly HttpApiClient _api;

        public TimeSpan HttpClientTimeout
        {
            get { return _api.Timeout; }
            set { _api.Timeout = value; }
        }

        public TelegramBotApi([NotNull] string token, string apiBase = "https://api.telegram.org/")
        {
            if (string.IsNullOrEmpty(token))
                throw new ArgumentNullException(nameof(token));
            if (string.IsNullOrEmpty(apiBase))
                throw new ArgumentNullException(nameof(apiBase));
            
            _api = new HttpApiClient(new Uri(apiBase), token);
        }

        public async Task<List<Update>> GetUpdatesAsync(int offset, int limit, int timeoutSeconds)
        {
            var args = new
            {
                offset = offset,
                limit = limit,
                timeout = timeoutSeconds
            };

            return await _api.GetAsync<List<Update>>(ApiMethod.GetUpdates, args)
                .ConfigureAwait(false);
        }

        public async Task<User> GetMeAsync()
        {
            return await _api.GetAsync<User>(ApiMethod.GetMe)
                .ConfigureAwait(false);
        }

        public async Task<Message> SendMessageAsync(int chatId, string text)
        {
            var args = new
            {
                chat_id = chatId,
                text = text
            };

            return await _api.GetAsync<Message>(ApiMethod.SendMessage, args)
                .ConfigureAwait(false);
        }

        public async Task<Message> SendMessageAsync(string channelUserName, string text)
        {
            var args = new
            {
                chat_id = channelUserName,
                text = text
            };

            return await _api.GetAsync<Message>(ApiMethod.SendMessage, args)
                .ConfigureAwait(false);
        }

        public async Task<Message> SendStickerAsync(int chatId, string sticker)
        {
            var args = new
            {
                chat_id = chatId,
                sticker = sticker
            };

            return await _api.GetAsync<Message>(ApiMethod.SendSticker, args)
                .ConfigureAwait(false);
        }

        public async Task<Message> SendStickerAsync(string channelUserName, string sticker)
        {
            var args = new
            {
                chat_id = channelUserName,
                sticker = sticker
            };

            return await _api.GetAsync<Message>(ApiMethod.SendSticker, args)
                .ConfigureAwait(false);
        }

        public async Task<Message> ForwardMessageAsync(int chatId, int fromChatId, int messageId)
        {
            var args = new
            {
                chat_id = chatId,
                from_chat_id = fromChatId,
                message_id = messageId
            };

            return await _api.GetAsync<Message>(ApiMethod.ForwardMessage, args)
                .ConfigureAwait(false);
        }

        public async Task<Message> ForwardMessageAsync(string channelUserName, string fromChannelUserName, int messageId)
        {
            var args = new
            {
                chat_id = channelUserName,
                from_chat_id = fromChannelUserName,
                message_id = messageId
            };

            return await _api.GetAsync<Message>(ApiMethod.ForwardMessage, args)
                .ConfigureAwait(false);
        }
        
        public async Task<Message> SendPhotoAsync(int chatId, File photo)
        {
            var args = new
            {
                chat_id = chatId,
                photo = photo
            };

            return await _api.GetAsync<Message>(ApiMethod.SendPhoto, args)
                .ConfigureAwait(false);
        }

        public async Task<Message> SendPhotoAsync(string channelUserName, string fileIdToResend)
        {
            var args = new
            {
                chat_id = channelUserName,
                photo = fileIdToResend
            };

            return await _api.GetAsync<Message>(ApiMethod.SendPhoto, args)
                .ConfigureAwait(false);           
        }

        public async Task<Message> SendAudioAsync(int chatId, Audio audio)
        {
            var args = new
            {
                chat_id = chatId,
                audio = audio
            };

            return await _api.GetAsync<Message>(ApiMethod.SendAudio, args)
                .ConfigureAwait(false);
        }

        public async Task<Message> SendAudioAsync(string channelUserName, string fileIdToResend)
        {
            var args = new
            {
                chat_id = channelUserName,
                audio = fileIdToResend
            };

            return await _api.GetAsync<Message>(ApiMethod.SendAudio, args)
                .ConfigureAwait(false);
        }

        public async Task<Message> SendDocumentAsync(int chatId, Document document)
        {
            var args = new
            {
                chat_id = chatId,
                document = document
            };

            return await _api.GetAsync<Message>(ApiMethod.SendDocument, args)
                .ConfigureAwait(false);
        }

        public async Task<Message> SendDocumentAsync(string channelUserName, string fileIdToResend)
        {
            var args = new
            {
                chat_id = channelUserName,
                document = fileIdToResend
            };

            return await _api.GetAsync<Message>(ApiMethod.SendDocument, args)
                .ConfigureAwait(false);
        }

        public async Task<Message> SendVideoAsync(int chatId, Video video)
        {
            var args = new
            {
                chat_id = chatId,
                video = video
            };

            return await _api.GetAsync<Message>(ApiMethod.SendVideo, args)
                .ConfigureAwait(false);
        }

        public async Task<Message> SendVideoAsync(string channelUserName, string fileIdToResend)
        {
            var args = new
            {
                chat_id = channelUserName,
                video = fileIdToResend
            };

            return await _api.GetAsync<Message>(ApiMethod.SendVideo, args)
                .ConfigureAwait(false);
        }

        public async Task<Message> SendVoiceAsync(int chatId, Voice voice)
        {
            var args = new
            {
                chat_id = chatId,
                voice = voice
            };

            return await _api.GetAsync<Message>(ApiMethod.SendVoice, args)
                .ConfigureAwait(false);
        }

        public async Task<Message> SendVoiceAsync(string channelUserName, string fileIdToResend)
        {
            var args = new
            {
                chat_id = channelUserName,
                voice = fileIdToResend
            };

            return await _api.GetAsync<Message>(ApiMethod.SendVoice, args)
                .ConfigureAwait(false);
        }

        public async Task<Message> SendLocationAsync(int chatId, float latitude, float longitude)
        {
            var args = new
            {
                chat_id = chatId,
                latitude = latitude,
                longitude = longitude
            };

            return await _api.GetAsync<Message>(ApiMethod.SendLocation, args)
                .ConfigureAwait(false);
        }

        public async Task<Message> SendLocationAsync(string channelUserName, float latitude, float longitude)
        {
            var args = new
            {
                chat_id = channelUserName,
                latitude = latitude,
                longitude = longitude
            };

            return await _api.GetAsync<Message>(ApiMethod.SendLocation, args)
                .ConfigureAwait(false);
        }

        public async Task<Message> SendVenueAsync(int chatId, float latitude, float longitude, string title, string address)
        {
            var args = new
            {
                chat_id = chatId,
                latitude = latitude,
                longitude = longitude,
                title = title,
                address = address
            };

            return await _api.GetAsync<Message>(ApiMethod.SendVenue, args)
               .ConfigureAwait(false);
        }

        public async Task<Message> SendVenueAsync(string channelUserName, float latitude, float longitude, string title, string address)
        {
            var args = new
            {
                chat_id = channelUserName,
                latitude = latitude,
                longitude = longitude,
                title = title,
                address = address
            };

            return await _api.GetAsync<Message>(ApiMethod.SendVenue, args)
              .ConfigureAwait(false);
        }

        public async Task<Message> SendContactAsync(int chatId, string phoneNumber, string firstName, string lastName)
        {
            var args = new
            {
                chat_id = chatId,
                phone_number = phoneNumber,
                first_name = firstName,
                last_name = lastName
            };

            return await _api.GetAsync<Message>(ApiMethod.SendContact, args)
                .ConfigureAwait(false);
        }

        public async Task<Message> SendContactAsync(string channelUserName, string phoneNumber, string firstName, string lastName)
        {
            var args = new
            {
                chat_id = channelUserName,
                phone_number = phoneNumber,
                first_name = firstName,
                last_name = lastName
            };

            return await _api.GetAsync<Message>(ApiMethod.SendContact, args)
                .ConfigureAwait(false);
        }

        public async Task<bool> SendChatActionAsync(int chatId, ChatAction action)
        {
            var args = new
            {
                chat_id = chatId,
                action = action
            };

            return await _api.GetAsync<bool>(ApiMethod.SendChatAction, args)
                .ConfigureAwait(false);
        }

        public async Task<bool> SendChatActionAsync(string channelUserName, ChatAction action)
        {
            var args = new
            {
                chat_id = channelUserName,
                action = action
            };

            return await _api.GetAsync<bool>(ApiMethod.SendChatAction, args)
                .ConfigureAwait(false);
        }

        public async Task<bool> KickChatMemberAsync(int chatId, int userId)
        {
            var args = new
            {
                chat_id = chatId,
                user_id = userId
            };

            return await _api.GetAsync<bool>(ApiMethod.KickChatMember, args)
                .ConfigureAwait(false);
        }

        public async Task<bool> KickChatMemberAsync(string channelUserName, int userId)
        {
            var args = new
            {
                chat_id = channelUserName,
                user_id = userId
            };

            return await _api.GetAsync<bool>(ApiMethod.KickChatMember, args)
                .ConfigureAwait(false);
        }

        public async Task<bool> LeaveChatAsync(int chatId)
        {
            var args = new
            {
                chat_id = chatId
            };

            return await _api.GetAsync<bool>(ApiMethod.LeaveChat, args)
                .ConfigureAwait(false);
        }

        public async Task<bool> LeaveChatAsync(string channelUserName)
        {
            var args = new
            {
                chat_id = channelUserName
            };

            return await _api.GetAsync<bool>(ApiMethod.LeaveChat, args)
                .ConfigureAwait(false);
        }

        public async Task<bool> UnbanChatMemberAsync(int chatId, int userId)
        {
            var args = new
            {
                chat_id = chatId,
                user_id = userId
            };

            return await _api.GetAsync<bool>(ApiMethod.UnbanChatMember, args)
                .ConfigureAwait(false);
        }

        public async Task<bool> UnbanChatMemberAsync(string channelUserName, int userId)
        {
            var args = new
            {
                chat_id = channelUserName,
                user_id = userId
            };

            return await _api.GetAsync<bool>(ApiMethod.UnbanChatMember, args)
                .ConfigureAwait(false);
        }

        public async Task<Chat> GetChatAsync(int chatId)
        {
            var args = new
            {
                chat_id = chatId
            };

            return await _api.GetAsync<Chat>(ApiMethod.GetChat, args)
                .ConfigureAwait(false);
        }

        public async Task<Chat> GetChatAsync(string channelUserName)
        {
            var args = new
            {
                chat_id = channelUserName
            };

            return await _api.GetAsync<Chat>(ApiMethod.GetChat, args)
                .ConfigureAwait(false);
        }

        public async Task<List<ChatMember>> GetChatAdminsAsync(int chatId)
        {
            var args = new
            {
                chat_id = chatId
            };

            return await _api.GetAsync<List<ChatMember>>(ApiMethod.GetChatAdmins, args)
                .ConfigureAwait(false);
        }

        public async Task<List<ChatMember>> GetChatAdminsAsync(string channelUserName)
        {
            var args = new
            {
                chat_id = channelUserName
            };

            return await _api.GetAsync<List<ChatMember>>(ApiMethod.GetChatAdmins, args)
                 .ConfigureAwait(false);
        }

        public async Task<int> GetChatMembersCountAsync(int chatId)
        {
            var args = new
            {
                chat_id = chatId
            };

            return await _api.GetAsync<int>(ApiMethod.GetChatMembersCount, args).ConfigureAwait(false);
        }

        public async Task<int> GetChatMembersCountAsync(string channelUserName)
        {
            var args = new
            {
                chat_id = channelUserName
            };

            return await _api.GetAsync<int>(ApiMethod.GetChatMembersCount, args).ConfigureAwait(false);
        }

        public async Task<ChatMember> GetChatMemberAsync(int chatId, int userId)
        {
            var args = new
            {
                chat_id = chatId,
                user_id = userId
            };

            return await _api.GetAsync<ChatMember>(ApiMethod.GetChatMember, args).ConfigureAwait(false);
        }

        public async Task<ChatMember> GetChatMemberAsync(string channelUserName, int userId)
        {
            var args = new
            {
                chat_id = channelUserName,
                user_id = userId
            };

            return await _api.GetAsync<ChatMember>(ApiMethod.GetChatMember, args).ConfigureAwait(false);
        }

        public async Task<UserProfilePhotos> GetUserProfilePhotoAsync(int userId)
        {
            var args = new
            {
                user_id = userId
            };

            return await _api.GetAsync<UserProfilePhotos>(ApiMethod.GetUserProfilePhotos, args)
                .ConfigureAwait(false);
        }

        public async Task<UserProfilePhotos> GetFileAsync(string fileId)
        {
            var args = new
            {
                file_id = fileId
            };

            return await _api.GetAsync<UserProfilePhotos>(ApiMethod.GetFile, args)
                .ConfigureAwait(false);
        }

        public void Dispose()
        {
            _api.Dispose();
        }
    }
}
