# Channel Chat Message Event

The `channel.chat.message` subscription type sends a notification when any user sends a message to a channel's chat room.

## Authorization

Requires `user:read:chat` scope from the chatting user. If app access token used, then additionally requires `user:bot` scope from chatting user, and either `channel:bot` scope from broadcaster or moderator status.

## Request Body

| Name | Type | Required | Description |
|------|------|----------|-------------|
| type | String | Yes | The subscription type name: `channel.chat.message` |
| version | String | Yes | The subscription type version: `1` |
| condition | condition | Yes | Subscription-specific parameters |
| transport | transport | Yes | Transport-specific parameters |

## Webhook Example

```json
{
    "type": "channel.chat.message",
    "version": "1",
    "condition": {
        "broadcaster_user_id": "1337",
        "user_id": "9001"
    },
    "transport": {
        "method": "webhook",
        "callback": "https://example.com/webhooks/callback",
        "secret": "s3cRe7"
    }
}
```

## Regular Chat Message Example

```json
{
  "subscription": {
    "id": "0b7f3361-672b-4d39-b307-dd5b576c9b27",
    "status": "enabled",
    "type": "channel.chat.message",
    "version": "1",
    "condition": {
      "broadcaster_user_id": "1971641",
      "user_id": "2914196"
    },
    "transport": {
      "method": "websocket",
      "session_id": "AgoQHR3s6Mb4T8GFB1l3DlPfiRIGY2VsbC1h"
    },
    "created_at": "2023-11-06T18:11:47.492253549Z",
    "cost": 0
  },
  "event": {
    "broadcaster_user_id": "1971641",
    "broadcaster_user_login": "streamer",
    "broadcaster_user_name": "streamer",
    "chatter_user_id": "4145994",
    "chatter_user_login": "viewer32",
    "chatter_user_name": "viewer32",
    "message_id": "cc106a89-1814-919d-454c-f4f2f970aae7",
    "message": {
      "text": "Hi chat",
      "fragments": [
        {
          "type": "text",
          "text": "Hi chat",
          "cheermote": null,
          "emote": null,
          "mention": null
        }
      ]
    },
    "color": "#00FF7F",
    "badges": [
      {
        "set_id": "moderator",
        "id": "1",
        "info": ""
      },
      {
        "set_id": "subscriber",
        "id": "12",
        "info": "16"
      },
      {
        "set_id": "sub-gifter",
        "id": "1",
        "info": ""
      }
    ],
    "message_type": "text",
    "cheer": null,
    "reply": null,
    "channel_points_custom_reward_id": null,
    "source_broadcaster_user_id": null,
    "source_broadcaster_user_login": null,
    "source_broadcaster_user_name": null,
    "source_message_id": null,
    "source_badges": null
  }
}
```

## Shared Chat Message Example

```json
{
  "subscription": {
    "id": "0b7f3361-672b-4d39-b307-dd5b576c9b27",
    "status": "enabled",
    "type": "channel.chat.message",
    "version": "1",
    "condition": {
      "broadcaster_user_id": "1971641",
      "user_id": "2914196"
    },
    "transport": {
      "method": "websocket",
      "session_id": "AgoQHR3s6Mb4T8GFB1l3DlPfiRIGY2VsbC1h"
    },
    "created_at": "2023-11-06T18:11:47.492253549Z",
    "cost": 0
  },
  "event": {
    "broadcaster_user_id": "1971641",
    "broadcaster_user_login": "streamer",
    "broadcaster_user_name": "streamer",
    "chatter_user_id": "4145994",
    "chatter_user_login": "viewer32",
    "chatter_user_name": "viewer32",
    "message_id": "cc106a89-1814-919d-454c-f4f2f970aae7",
    "message": {
      "text": "Hi chat",
      "fragments": [
        {
          "type": "text",
          "text": "Hi chat",
          "cheermote": null,
          "emote": null,
          "mention": null
        }
      ]
    },
    "color": "#00FF7F",
    "badges": [
      {
        "set_id": "moderator",
        "id": "1",
        "info": ""
      },
      {
        "set_id": "subscriber",
        "id": "12",
        "info": "16"
      },
      {
        "set_id": "sub-gifter",
        "id": "1",
        "info": ""
      }
    ],
    "message_type": "text",
    "cheer": null,
    "reply": null,
    "channel_points_custom_reward_id": null,
    "source_broadcaster_user_id": "112233",
    "source_broadcaster_user_login": "streamer33",
    "source_broadcaster_user_name": "streamer33",
    "source_message_id": "e03f6d5d-8ec8-4c63-b473-9e5fe61e289b",
    "source_badges": [
      {
        "set_id": "subscriber",
        "id": "3",
        "info": "3"
      }
    ],
    "is_source_only": true
  }
}
```