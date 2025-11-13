namespace ChoOnlineAPI.Models
{
    public enum UserRole
    {
        Buyer,
        Seller,
        Admin,
        Guest
    }

    public enum ProductCondition
    {
        New,
        Used,
        LikeNew
    }

    public enum ProductStatus
    {
        Available,
        Sold,
        Hidden
    }

    public enum AccountStatus
    {
        Active,
        Banned,
        Suspended,
        Restricted
    }

    public enum BanType
    {
        AccountBan,
        ChatBan,
        PostBan,
        CommentBan
    }

    public enum ReportType
    {
        Spam,
        Scam,
        Inappropriate,
        Fake,
        Harassment
    }

    public enum ReportStatus
    {
        Pending,
        UnderReview,
        Resolved,
        Rejected
    }

    public enum ReportPriority
    {
        Low,
        Medium,
        High,
        Urgent
    }

    public enum ResolutionAction
    {
        NoAction,
        Warning,
        Ban,
        ContentRemoved
    }

    public enum TransactionStatus
    {
        Pending,
        Completed,
        Cancelled
    }

    public enum TrustHistoryReason
    {
        PositiveReview,
        NegativeReview,
        ReportVerified,
        ReportFalse
    }

    public enum AdminActionType
    {
        Ban,
        Unban,
        ChatBan,
        Warning
    }
}
