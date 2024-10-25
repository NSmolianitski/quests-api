using Mapster;
using QuestsApi.Application.Quests.Commands.CreateQuest;
using QuestsApi.Contracts.Quests;
using QuestsApi.Domain.Quests;

namespace QuestsApi.Application.Common.Mapping;

public class QuestsMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<CreateQuestRequest, CreateQuestCommand>();
        
        config.NewConfig<Quest, QuestResponse>()
            .Map(dest => dest.Id, src => src.Id.Value);

        config.NewConfig<QuestCondition, QuestConditionResponse>();
        config.NewConfig<QuestReward, QuestRewardResponse>();

    }
}