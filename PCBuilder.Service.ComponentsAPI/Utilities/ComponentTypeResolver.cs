using PCBuilder.Service.ComponentsAPI.Models;

// Alias p.g.a. namnkonflikter
using Monitor = PCBuilder.Service.ComponentsAPI.Models.Monitor;
using OperatingSystem = PCBuilder.Service.ComponentsAPI.Models.OperatingSystem;

namespace PCBuilder.Service.ComponentsAPI.Utilities
{
    public class ComponentTypeResolver : IComponentTypeResolver
    {
        private readonly Dictionary<string, Type> _map;

        public ComponentTypeResolver()
        {
            // Lägg till alias/synonymer så att API:t känns trevligt att använda
            _map = new Dictionary<string, Type>(StringComparer.OrdinalIgnoreCase)
            {
                ["cpus"] = typeof(Cpu),
                ["cpu"] = typeof(Cpu),

                ["gpus"] = typeof(VideoCard),
                ["gpu"] = typeof(VideoCard),
                ["videocards"] = typeof(VideoCard),
                ["videocard"] = typeof(VideoCard),

                ["rams"] = typeof(MemoryKit),
                ["ram"] = typeof(MemoryKit),
                ["memorykits"] = typeof(MemoryKit),
                ["memorykit"] = typeof(MemoryKit),
                ["memory"] = typeof(MemoryKit),

                ["motherboards"] = typeof(Motherboard),
                ["motherboard"] = typeof(Motherboard),

                ["cases"] = typeof(Case),
                ["case"] = typeof(Case),

                ["psus"] = typeof(PowerSupply),
                ["psu"] = typeof(PowerSupply),
                ["powersupplies"] = typeof(PowerSupply),
                ["powersupply"] = typeof(PowerSupply),

                ["cpucoolers"] = typeof(CpuCooler),
                ["cpucooler"] = typeof(CpuCooler),

                ["casefans"] = typeof(CaseFan),
                ["casefan"] = typeof(CaseFan),

                ["internalstorages"] = typeof(InternalHardDrive),
                ["internalstorage"] = typeof(InternalHardDrive),
                ["internaldrives"] = typeof(InternalHardDrive),
                ["internaldrive"] = typeof(InternalHardDrive),

                ["externalstorages"] = typeof(ExternalHardDrive),
                ["externalstorage"] = typeof(ExternalHardDrive),
                ["externaldrives"] = typeof(ExternalHardDrive),
                ["externaldrive"] = typeof(ExternalHardDrive),

                ["monitors"] = typeof(Monitor),
                ["monitor"] = typeof(Monitor),

                ["keyboards"] = typeof(Keyboard),
                ["keyboard"] = typeof(Keyboard),

                ["mice"] = typeof(Mouse),
                ["mouse"] = typeof(Mouse),

                ["headphones"] = typeof(Headphones),
                ["headphone"] = typeof(Headphones),

                ["speakers"] = typeof(Speakers),
                ["speaker"] = typeof(Speakers),

                ["webcams"] = typeof(Webcam),
                ["webcam"] = typeof(Webcam),

                ["fancontrollers"] = typeof(FanController),
                ["fancontroller"] = typeof(FanController),

                ["soundcards"] = typeof(SoundCard),
                ["soundcard"] = typeof(SoundCard),

                ["ups"] = typeof(Ups),

                ["os"] = typeof(OperatingSystem),
                ["operatingsystems"] = typeof(OperatingSystem),
                ["operatingsystem"] = typeof(OperatingSystem),

                ["caseaccessories"] = typeof(CaseAccessory),
                ["caseaccessory"] = typeof(CaseAccessory),

                // Metadata-tabeller
                ["manufacturers"] = typeof(Manufacturer),
                ["manufacturer"] = typeof(Manufacturer),

                ["colors"] = typeof(Color),
                ["color"] = typeof(Color),

                ["formfactors"] = typeof(FormFactor),
                ["formfactor"] = typeof(FormFactor),
            };
        }

        public IEnumerable<string> Categories => _map.Keys.OrderBy(k => k);

        public bool TryResolve(string category, out Type? type) =>
            _map.TryGetValue(category, out type);
    }
}