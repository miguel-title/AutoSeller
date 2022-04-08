﻿// Decompiled with JetBrains decompiler
// Type: System.Web.Mvc.RedirectToRouteResult
// Assembly: System.Web.Mvc, Version=5.2.3.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CC73190B-AB9D-435C-8315-10FF295C572A
// Assembly location: C:\Workspace\Axinod V3 TMA\Developpement Monaco\AtomicSeller\packages\Microsoft.AspNet.Mvc.5.2.3\lib\net45\System.Web.Mvc.dll

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;

namespace AtomicSeller.Helpers.Security.Routing
{
    /// <summary>Représente un résultat qui effectue une redirection à l'aide du dictionnaire de valeurs d'itinéraire spécifié.</summary>
    public class RedirectToRouteResult : ActionResult
    {
        private RouteCollection _routes;

        /// <summary>Obtient une valeur qui indique si la redirection est permanente.</summary>
        /// <returns>true si la redirection doit être permanente ; sinon, false.</returns>
        public bool Permanent { get; private set; }

        /// <summary>Obtient ou définit le nom de l'itinéraire.</summary>
        /// <returns>Nom de l'itinéraire.</returns>
        public string RouteName { get; private set; }

        /// <summary>Obtient ou définit les valeurs d'itinéraire.</summary>
        /// <returns>Valeurs d'itinéraire.</returns>
        public RouteValueDictionary RouteValues { get; private set; }

        internal RouteCollection Routes
        {
            get
            {
                return this._routes;
            }
            set
            {
                this._routes = value;
            }
        }

        /// <summary>Initialise une nouvelle instance de la classe <see cref="T:System.Web.Mvc.RedirectToRouteResult" /> en utilisant les valeurs d'itinéraire spécifiées.</summary>
        /// <param name="routeValues">Valeurs d'itinéraire.</param>
        public RedirectToRouteResult(RouteValueDictionary routeValues)
            : this((string)null, routeValues)
        {
        }

        /// <summary>Initialise une nouvelle instance de la classe <see cref="T:System.Web.Mvc.RedirectToRouteResult" /> en utilisant le nom d'itinéraire et les valeurs d'itinéraire spécifiés.</summary>
        /// <param name="routeName">Nom de l'itinéraire.</param>
        /// <param name="routeValues">Valeurs d'itinéraire.</param>
        public RedirectToRouteResult(string routeName, RouteValueDictionary routeValues)
            : this(routeName, routeValues, false)
        {
        }

        /// <summary>Initialise une nouvelle instance de la classe <see cref="T:System.Web.Mvc.RedirectToRouteResult" /> à l'aide du nom d'itinéraire, des valeurs d'itinéraire et de l'indicateur de redirection permanente spécifiés.</summary>
        /// <param name="routeName">Nom de l'itinéraire.</param>
        /// <param name="routeValues">Valeurs d'itinéraire.</param>
        /// <param name="permanent">Valeur qui indique si la redirection est permanente.</param>
        public RedirectToRouteResult(string routeName, RouteValueDictionary routeValues, bool permanent)
        {
            this.Permanent = permanent;
            this.RouteName = routeName ?? string.Empty;
            this.RouteValues = routeValues ?? new RouteValueDictionary();
        }

       
    }
}
