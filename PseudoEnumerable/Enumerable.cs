﻿using System;
using System.Collections;
using System.Collections.Generic;

namespace PseudoEnumerable
{
    public static class Enumerable
    {
        
        /// <summary>
        /// Filters a sequence of values based on a predicate.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source</typeparam>
        /// <param name="source">An <see cref="IEnumerable{TSource}"/> to filter.</param>
        /// <param name="predicate">A function to test each source element for a condition</param>
        /// <returns>
        ///     An <see cref="IEnumerable{TSource}"/> that contains elements from the input
        ///     sequence that satisfy the condition.
        /// </returns>
        /// <exception cref="ArgumentNullException">Throws if <paramref name="source"/> is null.</exception>
        /// <exception cref="ArgumentNullException">Throws if <paramref name="predicate"/> is null.</exception>
        public static IEnumerable<TSource> Filter<TSource>(this IEnumerable<TSource> source,
            Func<TSource,bool> predicate)
        {
            if (source is null)
            {
                throw new ArgumentNullException("The source is null!");
            }

            if (predicate is null)
            {
                throw new ArgumentNullException("The predicate is null!");
            }

            IEnumerable<TSource> Select()
            {
                foreach (var item in source)
                {
                    if (predicate(item))
                    {
                        yield return item;
                    }
                }
            }
            return Select();
        }

        /// <summary>
        /// Transforms each element of a sequence into a new form.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source.</typeparam>
        /// <typeparam name="TResult">The type of the value returned by transformer.</typeparam>
        /// <param name="source">A sequence of values to invoke a transform function on.</param>
        /// <param name="transformer">A transform function to apply to each source element.</param>
        /// <returns>
        ///     An <see cref="IEnumerable{TResult}"/> whose elements are the result of
        ///     invoking the transform function on each element of source.
        /// </returns>
        /// <exception cref="ArgumentNullException">Throws if <paramref name="source"/> is null.</exception>
        /// <exception cref="ArgumentNullException">Throws if <paramref name="transformer"/> is null.</exception>
        public static IEnumerable<TResult> Transform<TSource, TResult>(this IEnumerable<TSource> source,
            Func<TSource, TResult> transformer)
        {
            if (source is null)
            {
                throw new ArgumentNullException("source is null");
            }

            if (transformer is null)
            {
                throw new ArgumentNullException("source is null");
            }

            foreach (var item in source)
            {
                yield return transformer(item);
            }
        }

        /// <summary>
        /// Sorts the elements of a sequence in ascending order according to a key.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source.</typeparam>
        /// <typeparam name="TKey">The type of the key returned by key.</typeparam>
        /// <param name="source">A sequence of values to order.</param>
        /// <param name="key">A function to extract a key from an element.</param>
        /// <returns>
        ///     An <see cref="IEnumerable{TSource}"/> whose elements are sorted according to a key.
        /// </returns>
        /// <exception cref="ArgumentNullException">Throws if <paramref name="source"/> is null.</exception>
        /// <exception cref="ArgumentNullException">Throws if <paramref name="key"/> is null.</exception>
        public static IEnumerable<TSource> SortBy<TSource, TKey>(this IEnumerable<TSource> source,
            Func<TSource, TKey> key)
        {
            
            if (source is null)
            {
                throw new ArgumentNullException("source is null");
            }
            if (key is null)
            {
                throw new ArgumentNullException("key is null");
            }
            List<TSource> lsrc = new List<TSource>(); 
            List<TKey> lkey = new List<TKey>();
            foreach (var item in source)
            {
               lsrc.Add(item);
               lkey.Add(key(item));
            }
            TSource[] asource = lsrc.ToArray();
            TKey[] akey = lkey.ToArray();
            Array.Sort<TKey,TSource>(akey, asource);
            IEnumerable<TSource> CustEnum(IEnumerable<TSource> result)
            {
                foreach (var item in result)
                {
                    yield return item;
                }
            }

            return CustEnum(asource);
           
        }

        /// <summary>
        /// Sorts the elements of a sequence in ascending order according by using a specified comparer for a key .
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source.</typeparam>
        /// <typeparam name="TKey">The type of the key returned by key.</typeparam>
        /// <param name="source">A sequence of values to order.</param>
        /// <param name="key">A function to extract a key from an element.</param>
        /// <param name="comparer">An <see cref="IComparer{T}"/> to compare keys.</param>
        /// <returns>
        ///     An <see cref="IEnumerable{TSource}"/> whose elements are sorted according to a key.
        /// </returns>
        /// <exception cref="ArgumentNullException">Throws if <paramref name="source"/> is null.</exception>
        /// <exception cref="ArgumentNullException">Throws if <paramref name="key"/> is null.</exception>
        /// <exception cref="ArgumentNullException">Throws if <paramref name="comparer"/> is null.</exception>
        public static IEnumerable<TSource> SortBy<TSource, TKey>(this IEnumerable<TSource> source,
            Func<TSource, TKey> key, IComparer<TKey> comparer)
        {

            if (source is null)
            {
                throw new ArgumentNullException("source is null");
            }
            if (key is null)
            {
                throw new ArgumentNullException("key is null");
            }
            List<TSource> lsrc = new List<TSource>();
            List<TKey> lkey = new List<TKey>();
            foreach (var item in source)
            {
                lsrc.Add(item);
                lkey.Add(key(item));
            }
            TSource[] asource = lsrc.ToArray();
            TKey[] akey = lkey.ToArray();
            Array.Sort<TKey, TSource>(akey, asource, comparer);
            IEnumerable<TSource> CustEnum(IEnumerable<TSource> result)
            {
                foreach (var item in result)
                {
                    yield return item;
                }
            }

            return CustEnum(asource);
        }

        /// <summary>
        /// Casts the elements of an IEnumerable to the specified type.
        /// </summary>
        /// <typeparam name="TResult">The type to cast the elements of source to.</typeparam>
        /// <param name="source">The <see cref="IEnumerable"/> that contains the elements to be cast to type TResult.</param>
        /// <returns>
        ///     An <see cref="IEnumerable{T}"/> that contains each element of the source sequence cast to the specified type.
        /// </returns>
        /// <exception cref="ArgumentNullException">Throws if <paramref name="source"/> is null.</exception>
        /// <exception cref="InvalidCastException">An element in the sequence cannot be cast to type TResult.</exception>
        public static IEnumerable<TResult> CastTo<TResult>(IEnumerable source)
        {
            if (source is null)
            {
                throw new ArgumentNullException($"source is null.");
            }

            if (source is IEnumerable<TResult> resultSource)
            {
                return resultSource;
            }

            return CustEnumerable();
            IEnumerable<TResult> CustEnumerable()
            {
                foreach (var item in source)
                {
                    if (item is TResult)
                    {
                        yield return (TResult)item;
                    }
                }
            }
        }

        /// <summary>
        /// Determines whether all elements of a sequence satisfy a condition.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source.</typeparam>
        /// <param name="source">A sequence of values.</param>
        /// <param name="predicate">A function to test each element for a condition.</param>
        /// <returns>
        ///     true if every element of the source sequence passes the test in the specified predicate,
        ///     or if the sequence is empty; otherwise, false
        /// </returns>
        /// <exception cref="ArgumentNullException">Throws if <paramref name="source"/> is null.</exception>
        /// <exception cref="ArgumentNullException">Throws if <paramref name="predicate"/> is null.</exception>
        public static bool ForAll<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            if (source is null)
            {
                throw new ArgumentNullException("The source is null!");
            }

            if (predicate is null)
            {
                throw new ArgumentNullException("The predicate is null!");
            }

            bool result = true;
            foreach (var item in source)
            {
                if (!predicate(item))
                {
                    result = false;
                }
            }
            return result;
            
        }
    }
}