﻿using System;
using System.Text.RegularExpressions;
using eth.Eve.PluginSystem;
using eth.Telegram.BotApi.Objects.Enums;

namespace eth.TestApp
{
    internal class PluginOne : IPlugin, IDisposable
    {
        private IPluginContext _ctx;

        public PluginInfo Info { get; } = new PluginInfo(new Guid("51b9ab14-7eab-4107-83bf-c9e50a2824f4"), 
                                                         "PluginOne", 
                                                         "Brand new Eve plugin", 
                                                         "0.0.0.1");

        public void Initialize(IPluginContext ctx)
        {
            _ctx = ctx;
        }

        public void Teardown()
        {
            Dispose();
        }

        public HandleResult Handle(IUpdateContext msg)
        {
            if (msg.IsInitiallyPolled)
                return HandleResult.Ignored;

            var update = msg.Update;

            if (update.Message.Chat.Id == -1001013065325)
            {
                var eva = new Regex(@"\bmiu\b", RegexOptions.IgnoreCase);

                if (eva.IsMatch(update.Message.Text ?? ""))
                {
                    _ctx.BotApi.SendMessageAsync(-1001013065325, "i'm here", ParseMode.None, null, null, update.Message.MessageId);
                    return HandleResult.HandledCompletely;
                }

                if (update.Message.From.Id == 146268050)
                {
                    var roll = new Random().Next(10);
                    if (roll == 7)
                        _ctx.BotApi.SendMessageAsync(-1001013065325, "юль, ну впиши по-братски");
                    return HandleResult.HandledCompletely;
                }
            }

            return HandleResult.Ignored;
        }

        public void Dispose() { }
    }
}
