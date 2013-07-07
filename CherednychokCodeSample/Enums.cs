using System;

namespace DataModelsLibrary
{
    /// <summary>
    /// Enumeration of user role
    /// </summary>
    public enum UserRole : byte
    {
        /// <summary>
        /// User has not a role yet
        /// </summary>
        None = 0,
        /// <summary>
        /// Administrator role, the most powerfull user
        /// </summary>
        Admin = 1,
        /// <summary>
        /// Student role
        /// </summary>
        Student = 2,
        /// <summary>
        /// Teacher role
        /// </summary>
        Teacher = 3,
        /// <summary>
        /// Guest role
        /// </summary>
        Guest = 4
    }

    /// <summary>
    /// Enumeration of the test modes
    /// </summary>
    public enum TestMode
    {
        /// <summary>
        /// Learning mode
        /// </summary>
        Learning = 0,
        /// <summary>
        /// Testing mode
        /// </summary>
        Testing = 1
    }

    /// <summary>
    /// Enumeration of question types
    /// </summary>
    public enum QuestionType
    {
        /// <summary>
        /// Question with one correct answer
        /// </summary>
        OneAnswer = 0,
        /// <summary>
        /// Multiple choice question
        /// </summary>
        MultipleAnswers = 1,
        /// <summary>
        /// Question with typing answer
        /// </summary>
        TypeAnswer = 2,
        /// <summary>
        /// Question to establish compliance //соответствие
        /// </summary>
        Compliance = 3,
        /// <summary>
        /// Question on the ordering //в правильной последовательности
        /// </summary>
        Ordering = 4,
        /// <summary>
        /// Question on the classification //по группам
        /// </summary>
        Classification = 5
    }

    /// <summary>
    /// Enumeration of the mark types
    /// </summary>
    public enum ProfileMarkType
    {
        /// <summary>
        /// Percent type
        /// </summary>
        Percent = 0,
        /// <summary>
        /// Standart mode
        /// </summary>
        Standart = 1
    }
}
