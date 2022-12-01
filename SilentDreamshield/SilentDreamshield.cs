using Modding;
using System;
using HutongGames.PlayMaker.Actions;
using SFCore.Utils;

namespace SilentDreamshield
{
    public class SilentDreamshieldMod : Mod
    {
        private static SilentDreamshieldMod? _instance;

        internal static SilentDreamshieldMod Instance
        {
            get
            {
                if (_instance == null)
                {
                    throw new InvalidOperationException($"An instance of {nameof(SilentDreamshieldMod)} was never constructed");
                }
                return _instance;
            }
        }

        public override string GetVersion() => GetType().Assembly.GetName().Version.ToString();

        public SilentDreamshieldMod() : base("SilentDreamshield")
        {
            _instance = this;
        }

        public override void Initialize()
        {
            Log("Initializing");

            On.PlayMakerFSM.OnEnable += OnFsmEnable;

            Log("Initialized");
        }
        
        private void OnFsmEnable(On.PlayMakerFSM.orig_OnEnable orig, PlayMakerFSM self)
        {
            orig(self);

            if (self.gameObject.name == "Shield" && self.FsmName == "Shield Hit")
            {
                self.GetFsmAction<AudioPlayerOneShotSingle>("Slash Anim", 1).Enabled = false;
            }
        }
    }
}
