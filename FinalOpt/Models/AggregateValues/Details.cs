using Newtonsoft.Json;

namespace FinalOpt.Models.AggregateValues
{
    public class Details
    {
        [JsonProperty("KPI.PROGRESS_CURRENT_OBJECTIVE")]
        public string KpiProgressCurrentObjective { get; set; }

        [JsonProperty("MODEL_DETAIL_CONSTRAINTS")]
        public long ModelDetailConstraints { get; set; }

        [JsonProperty("MODEL_DETAIL_INTEGER_VARS")]
        public long ModelDetailIntegerVars { get; set; }

        [JsonProperty("MODEL_DETAIL_OBJECTIVE_SENSE")]
        public string ModelDetailObjectiveSense { get; set; }

        [JsonProperty("MODEL_DETAIL_TYPE")]
        public string ModelDetailType { get; set; }

        [JsonProperty("PROGRESS_BEST_OBJECTIVE")]
        public long ProgressBestObjective { get; set; }

        [JsonProperty("PROGRESS_BEST_OBJECTIVE.history")]
        public string ProgressBestObjectiveHistory { get; set; }

        [JsonProperty("PROGRESS_CURRENT_OBJECTIVE")]
        public string ProgressCurrentObjective { get; set; }

        [JsonProperty("PROGRESS_CURRENT_OBJECTIVE.history")]
        public string ProgressCurrentObjectiveHistory { get; set; }

        [JsonProperty("PROGRESS_GAP")]
        public long ProgressGap { get; set; }

        [JsonProperty("PROGRESS_GAP.history")]
        public string ProgressGapHistory { get; set; }

        [JsonProperty("STAT.cpo.modelType")]
        public string StatCpoModelType { get; set; }

        [JsonProperty("STAT.cpo.size.constraints")]
        public long StatCpoSizeConstraints { get; set; }

        [JsonProperty("STAT.cpo.size.integerVariables")]
        public long StatCpoSizeIntegerVariables { get; set; }

        [JsonProperty("STAT.cpo.size.intervalVariables")]
        public long StatCpoSizeIntervalVariables { get; set; }

        [JsonProperty("STAT.cpo.size.sequenceVariables")]
        public long StatCpoSizeSequenceVariables { get; set; }

        [JsonProperty("STAT.cpo.size.variables")]
        public long StatCpoSizeVariables { get; set; }

        [JsonProperty("STAT.cpo.solve.memoryUsage")]
        public long StatCpoSolveMemoryUsage { get; set; }

        [JsonProperty("STAT.cpo.solve.numberOfBranches")]
        public long StatCpoSolveNumberOfBranches { get; set; }

        [JsonProperty("STAT.cpo.solve.time")]
        public string StatCpoSolveTime { get; set; }

        [JsonProperty("STAT.job.coresCount")]
        public long StatJobCoresCount { get; set; }

        [JsonProperty("STAT.job.inputsReadMs")]
        public long StatJobInputsReadMs { get; set; }

        [JsonProperty("STAT.job.memoryPeakKB")]
        public long StatJobMemoryPeakKb { get; set; }

        [JsonProperty("STAT.job.modelProcessingMs")]
        public long StatJobModelProcessingMs { get; set; }

        [JsonProperty("STAT.job.outputsWriteMs")]
        public long StatJobOutputsWriteMs { get; set; }

        [JsonProperty("latestOutputUpload")]
        public DateTimeOffset LatestOutputUpload { get; set; }
    }
}
