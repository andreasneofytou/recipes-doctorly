﻿// Code generated by Microsoft (R) AutoRest Code Generator 0.16.0.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace RecipesAPI.Client
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Rest;
    using Models;

    /// <summary>
    /// Extension methods for Auth.
    /// </summary>
    public static partial class AuthExtensions
    {
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='loginViewModel'>
            /// </param>
            public static object Login(this IAuth operations, Login loginViewModel)
            {
                return Task.Factory.StartNew(s => ((IAuth)s).LoginAsync(loginViewModel), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='loginViewModel'>
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<object> LoginAsync(this IAuth operations, Login loginViewModel, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.LoginWithHttpMessagesAsync(loginViewModel, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='registerViewModel'>
            /// </param>
            public static object Register(this IAuth operations, Register registerViewModel)
            {
                return Task.Factory.StartNew(s => ((IAuth)s).RegisterAsync(registerViewModel), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='registerViewModel'>
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<object> RegisterAsync(this IAuth operations, Register registerViewModel, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.RegisterWithHttpMessagesAsync(registerViewModel, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='userId'>
            /// </param>
            /// <param name='token'>
            /// </param>
            public static object ConfirmEmail(this IAuth operations, string userId = default(string), string token = default(string))
            {
                return Task.Factory.StartNew(s => ((IAuth)s).ConfirmEmailAsync(userId, token), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='userId'>
            /// </param>
            /// <param name='token'>
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<object> ConfirmEmailAsync(this IAuth operations, string userId = default(string), string token = default(string), CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.ConfirmEmailWithHttpMessagesAsync(userId, token, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='email'>
            /// </param>
            public static object ForgotPassword(this IAuth operations, string email)
            {
                return Task.Factory.StartNew(s => ((IAuth)s).ForgotPasswordAsync(email), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='email'>
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<object> ForgotPasswordAsync(this IAuth operations, string email, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.ForgotPasswordWithHttpMessagesAsync(email, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resetPasswordViewModel'>
            /// </param>
            public static object ResetPassword(this IAuth operations, ResetPassword resetPasswordViewModel)
            {
                return Task.Factory.StartNew(s => ((IAuth)s).ResetPasswordAsync(resetPasswordViewModel), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resetPasswordViewModel'>
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<object> ResetPasswordAsync(this IAuth operations, ResetPassword resetPasswordViewModel, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.ResetPasswordWithHttpMessagesAsync(resetPasswordViewModel, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

    }
}