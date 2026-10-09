namespace CebuSurvivalGuide.Models;

// Equivalent of auto_now_add / auto_now: AppDbContext fills these in on save.
public interface IHasCreatedAt { DateTime CreatedAt { get; set; } }
public interface IHasUpdatedAt { DateTime UpdatedAt { get; set; } }
