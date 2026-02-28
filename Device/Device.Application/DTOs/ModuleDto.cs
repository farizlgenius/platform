using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Device.Application.DTOs
{
    public sealed record ModuleDto(
        int Id,
        short SioId,
        short model,
        string ModelDetail,
        string Revision,
        string SerialNumber,
        short nHardwareId,
        string nHardwreIdDetail,
        int nHardwareRev,
        int nProductId,
        int nProductVer,
        int nEncConfig,
        string nEncConfigDetail,
        int nEncKeyStatus,
        int nEncKeyStatusDetail,
        List<ReaderDto> Readers,
        List<SensorDto> Sensors,
        List<StrikeDto> Strikes,
        List<RequestExitDto> REXs,
        List<> MonitorPoints,
        List<> ControlPoints,
        int Address,
        string AddressDetail,
        short Port,
        short nInput,
        short nOutput,
        short nReader,
        short Msp1No,
        short Baudrate,
        short nProtocol,
        short nDialext

        );
}
