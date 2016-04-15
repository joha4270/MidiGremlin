﻿using System.Runtime.InteropServices;

namespace MidiGremlin.Internal
{
    public struct SingleBeat
    {
        public SingleBeat(InstrumentType instrumentType, byte toneOffset, byte toneVelocity, int toneStartTime, int toneEndTime)
        {
            this.instrumentType = instrumentType;
            ToneOffset = toneOffset;
            ToneVelocity = toneVelocity;
            ToneStartTime = toneStartTime;
            ToneEndTime = toneEndTime;
        }

        public InstrumentType instrumentType{ get; }
        public byte ToneOffset{ get; }
        public byte ToneVelocity{ get; }
        public int ToneStartTime{ get; }
        public int ToneEndTime{ get; }
    }

    public struct SingleBeatWithChannel
    {
        public SingleBeatWithChannel(InstrumentType instrumentType, byte tone, byte toneVelocity, int toneStartTime, int toneEndTime, byte channel)
        {
            this.instrumentType = instrumentType;
            Tone = tone;
            ToneVelocity = toneVelocity;
            ToneStartTime = toneStartTime;
            ToneEndTime = toneEndTime;
            Channel = channel;
        }

        public InstrumentType instrumentType { get; }
        public byte Tone { get; }
        public byte ToneVelocity { get; }
        public int ToneStartTime { get; }
        public int ToneEndTime { get; }

        public  byte Channel { get; }
    }
}