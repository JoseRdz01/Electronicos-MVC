using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Electronicos_MVC.Models
{
    public class Enum
    {
        //es un tipo de datos que permite definir un conjunto de constantes con nombre. estas constantes represtan valores simbolios significativos y pueden ayudar a hacer que el codigo sea mas legible y mantenible 
        public enum NotificationType
        {
            error,
            success,
            warning,
            info,
            question
        }
    }
}