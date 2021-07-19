using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;

public class TextAnimation {
    Thread mThread;
    List<string> mTextQueue;
    string mRefText;
    int mTicks;
    int mOffset;
    int _queueOffset;

    bool _enabled;
    int _lastTick;
    public bool mEnable {
        get { return _enabled; }
        set {
            _enabled = value;
            if(_enabled && ( mThread.ThreadState == ThreadState.Unstarted ))
                mThread.Start();
            if(_enabled && mThread.ThreadState == ThreadState.Stopped ) {
                mThread = null;
                mThread = new Thread(new ThreadStart(Process));
                mThread.Start();
            }
        }
    }
    public TextAnimation(int tickRate) {
        mThread = new Thread(new ThreadStart(Process));
        mTextQueue = new List<string>();

        mRefText = "";

        _enabled = false;
        mTicks = tickRate;
        mOffset = 0;
        _queueOffset = 0;
    }

    public string GetString() {
        return mRefText;
    }

    public void AddTextToQueue(string text) {
        mTextQueue.Add(text);
    }

    ~TextAnimation() {
        _enabled = false;
        mThread = null;
    }
    public void Process() {
        while(_enabled) {
            
            if(mTextQueue.Count == 0)
                continue;
            if(Environment.TickCount-_lastTick > mTicks) {
                mRefText = mRefText + mTextQueue[_queueOffset][mOffset];
                mOffset++;
                if(mOffset >= mTextQueue[_queueOffset].Length) {
                    _queueOffset++;
                    mOffset = 0;
                }
                if(_queueOffset == mTextQueue.Count) {
                    _enabled = false;
                }
                _lastTick = Environment.TickCount;
            }
        }
    }

}
public class TextAnimator {
    private static List<TextAnimation> mListAnimations;

    static TextAnimator() {
        mListAnimations = new List<TextAnimation>();
    }
    
    public static TextAnimation CreateAnimation(int tickRate) {
        TextAnimation anim = new TextAnimation(tickRate);
        mListAnimations.Add(anim);
        return anim;
    }

    public static void DestroyAnimation(TextAnimation anim) {
        anim.mEnable = false;
        mListAnimations.Remove(anim);
        anim = null;
    }
}
