<?xml version="1.0"?>
<doc>
<members>
<member name="T:JulMar.Tapi3.TAPIOBJECT_EVENT" decl="false" source="c:\users\mark\documents\work\julmar entertainment\projects\itapi3\itapi3\events.h" line="38">
<summary>
The TAPIOBJECT_EVENT enum describes TAPI object events.
</summary>
</member>
<member name="T:JulMar.Tapi3.TapiObjectEventArgs" decl="false" source="c:\users\mark\documents\work\julmar entertainment\projects\itapi3\itapi3\events.h" line="52">
<summary>
The TapiObjectEventArgs class is sent with each TE_TAPIOBJECT event.
</summary>
</member>
<member name="P:JulMar.Tapi3.TapiObjectEventArgs.Address" decl="false" source="c:\users\mark\documents\work\julmar entertainment\projects\itapi3\itapi3\events.h" line="64">
<summary>
The Address object
</summary>
</member>
<member name="P:JulMar.Tapi3.TapiObjectEventArgs.Event" decl="false" source="c:\users\mark\documents\work\julmar entertainment\projects\itapi3\itapi3\events.h" line="77">
<summary>
The event being reported
</summary>
</member>
<member name="T:JulMar.Tapi3.ADDRESS_EVENT" decl="false" source="c:\users\mark\documents\work\julmar entertainment\projects\itapi3\itapi3\events.h" line="91">
<summary>
The different ADDRESS level events which are reported with a TapiAddressChangedEventArgs structure
</summary>
</member>
<member name="T:JulMar.Tapi3.TapiAddressChangedEventArgs" decl="false" source="c:\users\mark\documents\work\julmar entertainment\projects\itapi3\itapi3\events.h" line="107">
<summary>
The event structure reported with a TE_ADDRESS event
</summary>
</member>
<member name="P:JulMar.Tapi3.TapiAddressChangedEventArgs.Address" decl="false" source="c:\users\mark\documents\work\julmar entertainment\projects\itapi3\itapi3\events.h" line="119">
<summary>
The Address object
</summary>
</member>
<member name="P:JulMar.Tapi3.TapiAddressChangedEventArgs.Terminal" decl="false" source="c:\users\mark\documents\work\julmar entertainment\projects\itapi3\itapi3\events.h" line="127">
<summary>
The Terminal object (may be null)
</summary>
</member>
<member name="P:JulMar.Tapi3.TapiAddressChangedEventArgs.Event" decl="false" source="c:\users\mark\documents\work\julmar entertainment\projects\itapi3\itapi3\events.h" line="135">
<summary>
The event being reported
</summary>
</member>
<member name="T:JulMar.Tapi3.CALL_NOTIFICATION_EVENT" decl="false" source="c:\users\mark\documents\work\julmar entertainment\projects\itapi3\itapi3\events.h" line="149">
<summary>
The different events reported with a TapiCallNotificationEventArgs
</summary>
</member>
<member name="T:JulMar.Tapi3.TapiCallNotificationEventArgs" decl="false" source="c:\users\mark\documents\work\julmar entertainment\projects\itapi3\itapi3\events.h" line="158">
<summary>
This event structure is passed with a TE_CALLNOTIFICATION event
</summary>
</member>
<member name="P:JulMar.Tapi3.TapiCallNotificationEventArgs.Call" decl="false" source="c:\users\mark\documents\work\julmar entertainment\projects\itapi3\itapi3\events.h" line="169">
<summary>
The new call being reported
</summary>
</member>
<member name="P:JulMar.Tapi3.TapiCallNotificationEventArgs.Event" decl="false" source="c:\users\mark\documents\work\julmar entertainment\projects\itapi3\itapi3\events.h" line="177">
<summary>
The ownership of the call
</summary>
</member>
<member name="T:JulMar.Tapi3.CALL_STATE_EVENT_CAUSE" decl="false" source="c:\users\mark\documents\work\julmar entertainment\projects\itapi3\itapi3\events.h" line="191">
<summary>
The different call state event causes
</summary>
</member>
<member name="T:JulMar.Tapi3.CALL_STATE" decl="false" source="c:\users\mark\documents\work\julmar entertainment\projects\itapi3\itapi3\events.h" line="207">
<summary>
The different call states that a call may be in
</summary>
</member>
<member name="T:JulMar.Tapi3.TapiCallStateEventArgs" decl="false" source="c:\users\mark\documents\work\julmar entertainment\projects\itapi3\itapi3\events.h" line="222">
<summary>
The event structure reported with a TE_CALLSTATE event
</summary>
</member>
<member name="P:JulMar.Tapi3.TapiCallStateEventArgs.Call" decl="false" source="c:\users\mark\documents\work\julmar entertainment\projects\itapi3\itapi3\events.h" line="239">
<summary>
The call which has changed state
</summary>
</member>
<member name="P:JulMar.Tapi3.TapiCallStateEventArgs.State" decl="false" source="c:\users\mark\documents\work\julmar entertainment\projects\itapi3\itapi3\events.h" line="247">
<summary>
The new status of the call
</summary>
</member>
<member name="P:JulMar.Tapi3.TapiCallStateEventArgs.Cause" decl="false" source="c:\users\mark\documents\work\julmar entertainment\projects\itapi3\itapi3\events.h" line="255">
<summary>
The cause for the call state change
</summary>
</member>
<member name="T:JulMar.Tapi3.CALL_MEDIA_EVENT" decl="false" source="c:\users\mark\documents\work\julmar entertainment\projects\itapi3\itapi3\events.h" line="264">
<summary>
Different call media event types
</summary>
</member>
<member name="T:JulMar.Tapi3.CALL_MEDIA_EVENT_CAUSE" decl="false" source="c:\users\mark\documents\work\julmar entertainment\projects\itapi3\itapi3\events.h" line="277">
<summary>
The call media event cause
</summary>
</member>
<member name="T:JulMar.Tapi3.TapiCallMediaEventArgs" decl="false" source="c:\users\mark\documents\work\julmar entertainment\projects\itapi3\itapi3\events.h" line="292">
<summary>
This event argument structure is supplied with a TE_CALLMEDIA event
</summary>
</member>
<member name="P:JulMar.Tapi3.TapiCallMediaEventArgs.Call" decl="false" source="c:\users\mark\documents\work\julmar entertainment\projects\itapi3\itapi3\events.h" line="312">
<summary>
The call associated with the media event (may be null)
</summary>
</member>
<member name="P:JulMar.Tapi3.TapiCallMediaEventArgs.Terminal" decl="false" source="c:\users\mark\documents\work\julmar entertainment\projects\itapi3\itapi3\events.h" line="320">
<summary>
The terminal associated with the media event (may be null)
</summary>
</member>
<member name="P:JulMar.Tapi3.TapiCallMediaEventArgs.Stream" decl="false" source="c:\users\mark\documents\work\julmar entertainment\projects\itapi3\itapi3\events.h" line="328">
<summary>
The stream associated with the media event (may be null)
</summary>
</member>
<member name="P:JulMar.Tapi3.TapiCallMediaEventArgs.Error" decl="false" source="c:\users\mark\documents\work\julmar entertainment\projects\itapi3\itapi3\events.h" line="336">
<summary>
Any error reported (may be null)
</summary>
</member>
<member name="P:JulMar.Tapi3.TapiCallMediaEventArgs.Event" decl="false" source="c:\users\mark\documents\work\julmar entertainment\projects\itapi3\itapi3\events.h" line="344">
<summary>
The media event being reported
</summary>
</member>
<member name="P:JulMar.Tapi3.TapiCallMediaEventArgs.Cause" decl="false" source="c:\users\mark\documents\work\julmar entertainment\projects\itapi3\itapi3\events.h" line="352">
<summary>
The cause of the media event
</summary>
</member>
<member name="T:JulMar.Tapi3.TapiCallHubEventArgs" decl="false" source="c:\users\mark\documents\work\julmar entertainment\projects\itapi3\itapi3\events.h" line="361">
<summary>
This event argument structure is supplied with a CE_CALLHUB event
</summary>
</member>
<member name="P:JulMar.Tapi3.TapiCallHubEventArgs.Call" decl="false" source="c:\users\mark\documents\work\julmar entertainment\projects\itapi3\itapi3\events.h" line="377">
<summary>
The call associated with the hub (may be null)
</summary>
</member>
<member name="P:JulMar.Tapi3.TapiCallHubEventArgs.CallHub" decl="false" source="c:\users\mark\documents\work\julmar entertainment\projects\itapi3\itapi3\events.h" line="385">
<summary>
The call hub object
</summary>
</member>
<member name="T:JulMar.Tapi3.CALLINFOCHANGE_CAUSE" decl="false" source="c:\users\mark\documents\work\julmar entertainment\projects\itapi3\itapi3\events.h" line="394">
<summary>
The different types of call information which may change
</summary>
</member>
<member name="T:JulMar.Tapi3.TapiCallInfoChangeEventArgs" decl="false" source="c:\users\mark\documents\work\julmar entertainment\projects\itapi3\itapi3\events.h" line="428">
<summary>
This event argument structure is passed with a CE_CALLINFO event
</summary>
</member>
<member name="P:JulMar.Tapi3.TapiCallInfoChangeEventArgs.Call" decl="false" source="c:\users\mark\documents\work\julmar entertainment\projects\itapi3\itapi3\events.h" line="444">
<summary>
The call which has changed
</summary>
</member>
<member name="P:JulMar.Tapi3.TapiCallInfoChangeEventArgs.Cause" decl="false" source="c:\users\mark\documents\work\julmar entertainment\projects\itapi3\itapi3\events.h" line="452">
<summary>
The element in the call that has changed
</summary>
</member>
<member name="T:JulMar.Tapi3.LINEREQUESTMODE" decl="false" source="c:\users\mark\documents\work\julmar entertainment\projects\itapi3\itapi3\events.h" line="462">
<summary>
Describe different types of telephony requests that can be made from one application to another
</summary>
</member>
<member name="T:JulMar.Tapi3.TapiRequestEventArgs" decl="false" source="c:\users\mark\documents\work\julmar entertainment\projects\itapi3\itapi3\events.h" line="473">
<summary>
This structure details the assisted telephony requests and is passed with a TE_REQUEST event
</summary>
</member>
<member name="P:JulMar.Tapi3.TapiRequestEventArgs.RegistrationInstance" decl="false" source="c:\users\mark\documents\work\julmar entertainment\projects\itapi3\itapi3\events.h" line="514">
<summary>
The registration instance
</summary>
</member>
<member name="P:JulMar.Tapi3.TapiRequestEventArgs.RequestMode" decl="false" source="c:\users\mark\documents\work\julmar entertainment\projects\itapi3\itapi3\events.h" line="522">
<summary>
The LINEREQUESTMODE_xxx identifier
</summary>
</member>
<member name="P:JulMar.Tapi3.TapiRequestEventArgs.DestAddress" decl="false" source="c:\users\mark\documents\work\julmar entertainment\projects\itapi3\itapi3\events.h" line="530">
<summary>

</summary>
</member>
<member name="P:JulMar.Tapi3.TapiRequestEventArgs.AppName" decl="false" source="c:\users\mark\documents\work\julmar entertainment\projects\itapi3\itapi3\events.h" line="538">
<summary>

</summary>
</member>
<member name="P:JulMar.Tapi3.TapiRequestEventArgs.CalledParty" decl="false" source="c:\users\mark\documents\work\julmar entertainment\projects\itapi3\itapi3\events.h" line="546">
<summary>

</summary>
</member>
<member name="P:JulMar.Tapi3.TapiRequestEventArgs.Comment" decl="false" source="c:\users\mark\documents\work\julmar entertainment\projects\itapi3\itapi3\events.h" line="554">
<summary>

</summary>
</member>
</members>
</doc>
