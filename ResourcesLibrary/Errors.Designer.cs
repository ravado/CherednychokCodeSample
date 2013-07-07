﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.17929
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ResourcesLibrary {
    using System;
    
    
    /// <summary>
    ///   Класс ресурса со строгой типизацией для поиска локализованных строк и т.д.
    /// </summary>
    // Этот класс создан автоматически классом StronglyTypedResourceBuilder
    // с помощью такого средства, как ResGen или Visual Studio.
    // Чтобы добавить или удалить член, измените файл .ResX и снова запустите ResGen
    // с параметром /str или перестройте свой проект VS.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class Errors {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Errors() {
        }
        
        /// <summary>
        ///   Возвращает кэшированный экземпляр ResourceManager, использованный этим классом.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("ResourcesLibrary.Errors", typeof(Errors).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Перезаписывает свойство CurrentUICulture текущего потока для всех
        ///   обращений к ресурсу с помощью этого класса ресурса со строгой типизацией.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Connection string {0} is missed in app.config.
        /// </summary>
        public static string ConStringMissedApp {
            get {
                return ResourceManager.GetString("ConStringMissedApp", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Inner exception: .
        /// </summary>
        public static string Exception {
            get {
                return ResourceManager.GetString("Exception", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Invalid property name: .
        /// </summary>
        public static string InvalidPropertyName {
            get {
                return ResourceManager.GetString("InvalidPropertyName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на The lenght of the name must be between 2 and 100..
        /// </summary>
        public static string LenghtName {
            get {
                return ResourceManager.GetString("LenghtName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Can&apos;t perform an add operation. Reason: data model is null..
        /// </summary>
        public static string NotAddedDataModelNull {
            get {
                return ResourceManager.GetString("NotAddedDataModelNull", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Can&apos;t convert data model to entity. Reason: data model is null..
        /// </summary>
        public static string NotConvertedDMToEntityDMNull {
            get {
                return ResourceManager.GetString("NotConvertedDMToEntityDMNull", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Can&apos;t convert data model to entity. Reason: transfer properties error. {0}.
        /// </summary>
        public static string NotConvertedDMToEntityPropertiesError {
            get {
                return ResourceManager.GetString("NotConvertedDMToEntityPropertiesError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Can&apos;t convert entity to data model. Reason: entity is null..
        /// </summary>
        public static string NotConvertedEntityToDMEntiryNull {
            get {
                return ResourceManager.GetString("NotConvertedEntityToDMEntiryNull", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Can&apos;t perform edit operation. Reason: object to edit is null..
        /// </summary>
        public static string NotEditedObjectNull {
            get {
                return ResourceManager.GetString("NotEditedObjectNull", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Can&apos;t get data from database. {0}. {1}.
        /// </summary>
        public static string NotGetDataDB {
            get {
                return ResourceManager.GetString("NotGetDataDB", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Can&apos;t perform an remove operation. Reason: data model is null..
        /// </summary>
        public static string NotRemovedDataModelNull {
            get {
                return ResourceManager.GetString("NotRemovedDataModelNull", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Can&apos;t perform select operation. Reason: predicate is null..
        /// </summary>
        public static string NotSelectedPredicateNull {
            get {
                return ResourceManager.GetString("NotSelectedPredicateNull", resourceCulture);
            }
        }
    }
}
