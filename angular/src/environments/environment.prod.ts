import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

export const environment = {
  production: true,
  application: {
    baseUrl,
    name: 'TVersion',
    logoUrl: '',
  },
  oAuthConfig: {
    issuer: 'https://localhost:44385',
    redirectUri: baseUrl,
    clientId: 'TVersion_App',
    responseType: 'code',
    scope: 'offline_access TVersion',
  },
  apis: {
    default: {
      url: 'https://localhost:44385',
      rootNamespace: 'TVersion',
    },
  },
} as Environment;
