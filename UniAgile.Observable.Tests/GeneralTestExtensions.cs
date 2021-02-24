using System;

namespace UniAgile.Observable.Tests
{
    public static class GeneralTestExtensions
    {
        public static T then_it<T>(this T param)
        {
            return param;
        }

        public static T then_the<TSelf, T>(this TSelf self,
                                           T          param)
        {
            return param;
        }

        public static T but_then<TSelf, T>(this TSelf self,
                                           T          param)
        {
            return param;
        }

        public static TSelf and_then<TSelf>(this TSelf self)
        {
            return self;
        }

        public static T and_then<TSelf, T>(this TSelf self,
                                           T          param)
        {
            return param;
        }

        public static TSelf and_then<TSelf>(this TSelf self,
                                            Action     action)
        {
            action();

            return self;
        }

        public static TSelf and_then<TSelf, T>(this TSelf self,
                                               Action<T>  action,
                                               T          param)
        {
            action(param);

            return self;
        }

        public static T and_has<TSelf, T>(this TSelf self,
                                          T          param)
        {
            return param;
        }

        public static T has<T>(this T param,
                               Action action)
        {
            action();

            return param;
        }

        public static T has<T>(this T    param,
                               Action<T> action)
        {
            action(param);

            return param;
        }

        public static T and<T>(this T param)
        {
            return param;
        }

        public static T are<T>(this T param)
        {
            return param;
        }

        public static T will<T>(this T param)
        {
            return param;
        }

        public static T when<T>(this T param,
                                Action action)
        {
            action();

            return param;
        }

        public static T when<T>(this T    param,
                                Action<T> action)
        {
            action(param);

            return param;
        }

        public static TSelf when<TSelf, T>(this TSelf self,
                                           Action<T>  action,
                                           T          param)
        {
            action(param);

            return self;
        }

        public static T then<T>(this T param,
                                Action action)
        {
            action();

            return param;
        }

        public static T then<T>(this T    param,
                                Action<T> action)
        {
            action(param);

            return param;
        }

        public static TSelf then<TSelf, T>(this TSelf self,
                                           Action<T>  action,
                                           T          param)
        {
            action(param);

            return self;
        }


        public static T given_that<T>(this T param,
                                      Action action)
        {
            action();

            return param;
        }


        public static T given_that<TSelf, T>(this TSelf self,
                                             T          param)
        {
            return param;
        }

        public static T given_that<T>(this T    param,
                                      Action<T> action)
        {
            action(param);

            return param;
        }

        public static T feature_works_given_that<TSelf, T>(this TSelf self,
                                                           T          param)
        {
            return param;
        }

        public static T feature_works_given_that<T>(this T param,
                                                    Action action)
        {
            action();

            return param;
        }

        public static T feature_works_given_that<T>(this T    param,
                                                    Action<T> action)
        {
            action(param);

            return param;
        }
    }
}