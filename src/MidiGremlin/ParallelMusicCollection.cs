﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using MidiGremlin.Internal;

namespace MidiGremlin
{
    ///<summary>
    ///The class ParallelMusicCollection inherits from the class MusicObject.
    ///The class consist of a list of MusicObjects, which will be played simultaneously. 
    ///</summary>
    public class ParallelMusicCollection : MusicObject, IList<MusicObject>
    {
        List<MusicObject> _children = new List<MusicObject>();
        /// <summary>
        /// Adds a number of MusicObjects to parralellmusicCollection 
        /// </summary>
        /// <param name="children">A number of MusicObjects</param>
        public ParallelMusicCollection (IEnumerable<MusicObject> children)
        {
            foreach(MusicObject m in children)
            {
                Add(m);
            }
        }
        /// <summary>
        /// Adds a number of MusicObjects to parralellmusicCollection.
        /// Give it at least 1 parameter
        /// </summary>
        /// <param name="children">A number of MusicObjects.</param>
        public ParallelMusicCollection (params MusicObject[] children)
        {
            foreach (MusicObject m in children)
            {
                Add(m);
            }
        }
        /// <summary>
        ///  Gets and sets MusicObject from the indicated index.
        /// </summary>
        /// <param name="index">Indicated index where it gets and sets MusicObject</param>
        /// <returns></returns>
        public MusicObject this[int index]
        {
            get
            {
                return _children[index];
            }

            set
            {
                _children[index] = value;
            }
        }
        /// <summary>
        /// Gets the number of elements contained in the list
        /// </summary>
        public int Count
        {
            get
            {
                return _children.Count;
            }
        }
        /// <summary>
        /// Checks if it is readonly
        /// </summary>
        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// Adds MusicObject to list
        /// </summary>
        /// <param name="item">Is a MusicObject</param>
        public void Add (MusicObject item)
        {
            _children.Add(item);
        }
        /// <summary>
        /// Clears the list
        /// </summary>
        public void Clear ()
        {
            _children.Clear();
        }
        /// <summary>
        /// Checks if it is contained in list
        /// </summary>
        /// <param name="item">Is a MusicObject</param>
        /// <returns></returns>
        public bool Contains (MusicObject item)
        {
            return _children.Contains(item);
        }
        /// <summary>
        /// Copies to list
        /// </summary>
        /// <param name="array">Is a MusicObject array</param>
        /// <param name="arrayIndex">Index of the array</param>
        public void CopyTo (MusicObject[] array, int arrayIndex)
        {
            _children.CopyTo(array, arrayIndex);
        }
        /// <summary>
        /// An enumerator that iterates through the list
        /// </summary>
        /// <returns>Returns an enumerator that iterates through the list</returns>
        public IEnumerator<MusicObject> GetEnumerator ()
        {
            return _children.GetEnumerator();
        }
        /// <summary>
        /// Searches  for the specified object and returns the index of the first occurrence within the list
        /// </summary>
        /// <param name="item">The object which the list is seaching for</param>
        /// <returns>Returns the index of the object searched for</returns>
        public int IndexOf (MusicObject item)
        {
            return _children.IndexOf(item);
        }
        /// <summary>
        /// Inserts an element into the list at the specified list
        /// </summary>
        /// <param name="index">Index where the element is inserted </param>
        /// <param name="item">Element inserted </param>
        public void Insert (int index, MusicObject item)
        {
            _children.Insert(index, item);
        }
        /// <summary>
        /// Removes the first occurrence of the object within the list
        /// </summary>
        /// <param name="item"> Specified object which should be removed </param>
        /// <returns>Returns a list without the spicified object</returns>
        public bool Remove (MusicObject item)
        {
            return _children.Remove(item);
        }
        /// <summary>
        /// Removed the element at a specified index
        /// </summary>
        /// <param name="index">Index where the element is removed</param>
        public void RemoveAt (int index)
        {
            _children.RemoveAt(index);
        }

        internal override IEnumerable<SingleBeat> GetChildren (Instrument playedBy, double startTime)
        {
            List<SingleBeat> sBeats = new List<SingleBeat>();
            foreach (MusicObject m in _children)
            {
                foreach (SingleBeat sb in m.GetChildren(playedBy, startTime))
                {
                    sBeats.Add(sb);
                }
            }
            sBeats = sBeats.OrderBy(sb => sb.ToneStartTime).ToList();

            foreach (SingleBeat sb in sBeats)
            {
                yield return sb;
            }
            
        }

        IEnumerator IEnumerable.GetEnumerator ()
        {
            return _children.GetEnumerator();
        }
    }
}