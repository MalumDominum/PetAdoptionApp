## Run in Kubernetes Cluster via Helm

```cli
cd charts\petadopt
helm dependency build
helm install petadopt --namespace petadopt . --create-namespace
```

###### Check the Diff command

```cli
helm diff upgrade petadopt --namespace petadopt .
```

###### Upgrade command

```cli
helm upgrade petadopt --namespace petadopt .
```
