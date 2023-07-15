// Copied from https://github.com/serilog/serilog/issues/1523#issuecomment-754480512
using System.Collections.Generic;
using Serilog.Core;
using Serilog.Events;

namespace SharpBukkit.Server;

public class RemoveTypeTagEnricher : ILogEventEnricher {
	public void Enrich(LogEvent le, ILogEventPropertyFactory lepf) {
		foreach (var p in le.Properties) {
			if (p.Value is StructureValue sv) {
				le.AddOrUpdateProperty(new LogEventProperty(p.Key, RemoveTypeTag(sv)));
			}
		}
	}

	private StructureValue RemoveTypeTag(StructureValue sv) {
		return new StructureValue(RemoveTypeTag(sv.Properties), typeTag: null);
	}

	private IEnumerable<LogEventProperty> RemoveTypeTag(IEnumerable<LogEventProperty> props) {
		foreach (var p in props) {
			if (p.Value is StructureValue sv)
				yield return new LogEventProperty(p.Name, RemoveTypeTag(sv));
			else
				yield return p;
		}
	}
}
