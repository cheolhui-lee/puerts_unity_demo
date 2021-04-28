using System;
using System.Collections;
using System.Collections.Generic;
using Puerts;
using UnityEngine;

namespace PuertsTest
{
    public class NullComponentTestBehaviour : MonoBehaviour
    {
        public delegate void ModuleInit(NullComponentTestBehaviour monoBehaviour);

        public string ModuleName;

        public Action JsStart;

        static JsEnv jsEnv;

        void Awake()
        {
            if (jsEnv == null) jsEnv = new JsEnv();

            var init = jsEnv.Eval<ModuleInit>("const m = require('" + ModuleName + "'); m.init;");

            if (init != null) init(this);
        }

        void Start()
        {
            if (JsStart != null) JsStart();
        }

        void OnDestroy()
        {
            JsStart = null;
        }
    }
}
